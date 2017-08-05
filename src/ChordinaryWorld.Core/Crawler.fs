module Crawler

open Result

let GetTabs (artist, title) =
    let htmlGenerator (x) = 
        (artist, title, x)
        |> UrlMaker.MakeUrl
        |> Downloader.DownloadHtml

    htmlGenerator
    |> Seq.initInfinite
    |> Seq.skip 1
    |> Seq.takeWhile (fun x -> x.IsSome)
    |> Seq.choose id

let ChooseBestTab tabs =
    tabs
    |> Seq.map (fun tab -> (tab, HtmlParser.GetRatingFromHtml(tab)))
    |> Seq.maxBy snd
    |> fst

let GetTab (artist: string, title: string) =
    let tabs = GetTabs(artist, title)
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