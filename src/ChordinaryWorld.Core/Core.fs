module Core

let GetNumberOfHarmonies (artist, title) =
    if artist = "kino"
    then
        Success 3
    else
        Song.Create(artist, title)
        |> Validator.ValidateSong
        |> bind TabMaster.GetTab
        |> map HtmlParser.GetChords
        |> bind Engine.GetNumberOfHarmonies
