module Core

let GetNumberOfHarmonies song =
    if fst song = "kino"
    then
        Some 3
    else
        let tab = 
            song
            |> Formatter.FormatSong
            |> Crawler.GetTab

        match tab with
        | Some(x) -> 
            x 
            |> HtmlParser.GetChords
            |> Engine.GetNumberOfHarmonies
            |> Some
        | None -> 
            None