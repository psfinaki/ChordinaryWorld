module Core

let GetNumberOfHarmonies song =
    song
    |> Validator.ValidateSong
    |> bind ChordsProvider.GetChords
    |> bind Engine.GetNumberOfHarmonies
    |> consider (DatabaseConnector.Save song) (UnknownDatabaseErrorHarmonies, UnknownDatabaseIssue)
    |> Logger.Log song

let GetTop count =
    count
    |> Validator.ValidateCount
    |> bind DatabaseConnector.GetTop 
