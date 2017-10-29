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

let GetArtistTop artist = 
    artist
    |> Validator.ValidateArtist
    |> bind (Crawler.GetTopTracks 5)
    |> map (Seq.mapZip GetNumberOfHarmonies)
    |> bind ArtistTopMaster.CreateTop

