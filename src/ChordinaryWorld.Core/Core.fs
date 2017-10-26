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
    |> bind (fun tracks -> 
        let top =
            Seq.allPairs [artist] tracks
            |> Seq.map (fun song -> (song, GetNumberOfHarmonies song))
            |> Seq.choose (fun (song, result) -> 
                match result with
                | Success (harmonies,_) -> Some (snd song, harmonies)
                | Failure _ -> None
            )
            |> Seq.sortByDescending snd

        match Seq.length top with
        | 0 -> 
            Failure NoTabsFound
        | x ->
            let count = if x > 3 then 3 else x
            top
            |> Seq.take count
            |> succeed
    )

