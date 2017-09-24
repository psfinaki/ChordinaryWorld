module DatabaseConnector

type Song = { 
    id: string; 
    artist : string; 
    title : string; 
    harmonies: int 
}

let SaveSong (artist, title) harmonies =
    { 
        id = artist + " - " + title;
        artist = artist; 
        title = title; 
        harmonies = harmonies 
    }
    |> AzureConnector.SaveDocument
    
let Save song harmonies =
    try
        SaveSong song harmonies
        succeed harmonies 
    with
        _ -> Failure UnknownDatabaseError