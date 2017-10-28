module internal ArtistTopMaster

let GetTopSongsMax3 songs =
    let length = Seq.length songs
    let count = if length > 3 then 3 else length
    
    songs
    |> Seq.sortByDescending snd
    |> Seq.take count
    |> Seq.map (fun (song, harmonies) -> snd song, harmonies)

let CreateTop results = 
    let values = results |> choose2 optSuccess
    let errors = results |> choose2 optFailure |> Seq.map snd

    let chordsAvailable = not <| Seq.contains ChordsNotAvailable errors
    match chordsAvailable with
    | false -> 
        Failure TabsUnuavailable
    | true -> 
        match Seq.length values with
        | 0 ->
            if Seq.forall ((=) ChordsNotFound) errors
            then Failure NoTabsFound
            else Failure BadTabs
        | _ ->
            values
            |> GetTopSongsMax3 
            |> succeed
