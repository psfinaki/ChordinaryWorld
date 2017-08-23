module internal TabMaster

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

let ChooseBestTab tabs =
    tabs
    |> Seq.map (fun tab -> (tab, HtmlParser.GetRating tab))
    |> Seq.maxBy snd
    |> fst

let GetTab song =
    let tabs = 
        cartesian (GetVariations song.Artist) (GetVariations song.Title)
        |> Seq.map Song.Create
        |> Seq.collect Crawler.GetTabs

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