module internal DatabaseConnector

let Save song harmonies =
    try
        let (artist, title) = tupleMap Canonicalizer.Canonicalize song
    
        Song (artist, title, harmonies)
        |> AzureConnector.SaveDocument

        succeed harmonies 
    with
        _ -> Failure UnknownDatabaseIssue

let GetTop count =
    try
        AzureConnector.GetTop count
        |> succeed
    with 
        _ -> Failure UnknownDatabaseIssue
