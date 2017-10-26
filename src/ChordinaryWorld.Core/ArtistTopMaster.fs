module internal ArtistTopMaster

let CreateTop results = 
    let top =
        results
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