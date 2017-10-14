module Core

let GetNumberOfHarmonies song =
    song
    |> liftE Validator.ValidateSong
    |> bindE ChordsProvider.GetChords
    |> bindI Engine.GetNumberOfHarmonies
    |> considerI (DatabaseConnector.Save song) (InternalError UnknownDatabaseError, UnknownDatabaseIssue)
    |> Logger.Log song

let GetTop count =
    count
    |> liftI DatabaseConnector.GetTop 
