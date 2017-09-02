module Core

let GetNumberOfHarmonies (artist, title) =
    if artist = "kino"
    then
        Success 3
    else
        (artist, title)
        |> Validator.ValidateSong
        |> bind ChordsProvider.GetChords
        |> bind Engine.GetNumberOfHarmonies
