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

let Save song result = 
    match result with 
    | Success number -> SaveSong song number
    | Failure _ -> ()

    result