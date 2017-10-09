module Core

let GetNumberOfHarmonies song =
    song
    |> Validator.ValidateSong
    |> bind ChordsProvider.GetChords
    |> bind Engine.GetNumberOfHarmonies
    |> consider (DatabaseConnector.Save song)
    |> Logger.Log song

let GetTop =
    DatabaseConnector.GetTop
