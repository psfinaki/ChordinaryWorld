module internal Crawler

let GetVariations (s: string) =
    seq {
        match s with
        | s when s.Contains " & " ->
            yield s.Replace(" & ", " and ")
            yield s.Replace(" & ", " ")
        | s when s.Contains " + " ->
            yield s.Replace(" + ", " and ")
            yield s.Replace(" + ", " ")
        | _ ->
            yield s
    }

let GetTabs song =
    let htmlGenerator x = 
        song
        |> Canonicalizer.CanonicalizeSong
        |> UrlMaker.MakeUrl x
        |> Downloader.DownloadHtml

    htmlGenerator
    |> Seq.initInfinite
    |> Seq.skip 1
    |> Seq.takeWhile (fun x -> x.IsSome)
    |> Seq.choose id

let ChooseBestTab tabs =
    tabs
    |> Seq.map (fun tab -> (tab, HtmlParser.GetRating tab))
    |> Seq.maxBy snd
    |> fst

let GetTab song =
    let tabs = 
        GetVariations song.Title
        |> cartesian (GetVariations song.Artist)
        |> Seq.map Song.Create
        |> Seq.collect GetTabs

    match Seq.length tabs with
    | 0 -> 
        Failure ChordsNotFound
    | 1 -> 
        tabs 
        |> Seq.exactlyOne
        |> Success
    | _ ->
        tabs
        |> ChooseBestTab
        |> Success