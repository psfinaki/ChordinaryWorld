module internal DatabaseConnector

let SaveSong (artist, title) harmonies =
    Song (artist, title, harmonies)
    |> AzureConnector.SaveDocument
    
let Save song harmonies =
    try
        SaveSong song harmonies
        succeed harmonies 
    with
        _ -> Failure UnknownDatabaseIssue