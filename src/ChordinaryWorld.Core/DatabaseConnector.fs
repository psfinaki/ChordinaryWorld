module internal DatabaseConnector

let SaveSong song harmonies =
    let (artist, title) = tupleMap Canonicalizer.Canonicalize song
    
    Song (artist, title, harmonies)
    |> AzureConnector.SaveDocument
    
let Save song harmonies =
    try
        SaveSong song harmonies
        succeed harmonies 
    with
        _ -> Failure UnknownDatabaseIssue