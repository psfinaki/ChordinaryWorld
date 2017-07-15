module Core

let GetNumberOfChords song =
    if fst song = "kino"
    then
        3
        |> Some
    else
        let html = 
            song
            |> UrlGod.MakeUrl
            |> Downloader.DownloadHtml

        match html with
        | Some(x) -> 
            x 
            |> HtmlParser.GetChords
            |> Engine.GetNumberOfChords
            |> Some
        | None -> 
            None