module Core

let GetNumberOfHarmonies (artist, title) =
    (artist, title)
    |> Validator.ValidateSong
    |> bind ChordsProvider.GetChords
    |> bind Engine.GetNumberOfHarmonies
