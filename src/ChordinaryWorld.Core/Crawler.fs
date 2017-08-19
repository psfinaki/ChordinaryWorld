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

let GetTabs (artist, title) =
    let canonicalized = Canonicalizer.CanonicalizeSong (artist, title)
    let htmlGenerator x = 
        (fst canonicalized, snd canonicalized, x)
        |> UrlMaker.MakeUrl
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

let GetTab (artist, title) =
    let tabs = 
        GetVariations title
        |> cartesian (GetVariations artist)
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