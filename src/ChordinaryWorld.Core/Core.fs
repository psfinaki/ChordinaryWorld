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
    |> Crawler.GetTopTracks 5
    |> Seq.allPairs [artist]
    |> Seq.map    (fun  song -> (song, GetNumberOfHarmonies song))
    |> Seq.choose (fun (song, result) -> 
        match result with
        | Success (harmonies,_) -> Some (snd song, harmonies)
        | Failure _ -> None
    )
    |> Seq.sortByDescending snd
    |> Seq.head
