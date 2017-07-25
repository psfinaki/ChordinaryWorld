module Core

let GetNumberOfHarmonies song =
    if fst song = "kino"
    then
        3
        |> Some
    else
        let html = 
            song
            |> Formatter.FormatSong
            |> UrlMaker.MakeUrl
            |> Downloader.DownloadHtml

        match html with
        | Some(x) -> 
            x 
            |> HtmlParser.GetChords
            |> Engine.GetNumberOfHarmonies
            |> Some
        | None -> 
            None