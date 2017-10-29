module internal DatabaseConnector

let Save song harmonies =
    try
        let (artist, title) = Tuple.map Canonicalizer.Canonicalize song
    
        Song (artist, title, harmonies)
        |> AzureConnector.SaveDocument

        succeed harmonies 
    with
        _ -> Failure UnknownDatabaseErrorHarmonies

let GetTop count =
    try
        AzureConnector.GetTop count
    with 
        _ -> Failure UnknownDatabaseErrorTop
