module DatabaseConnector

type Song = { Artist : string; Title : string; Harmonies: int }

let SaveSong (artist, title) harmonies =
    { Artist = artist; Title = title; Harmonies = harmonies }
    |> AzureConnector.SaveDocument 

let Save song result = 
    match result with 
    | Success number -> SaveSong song number
    | Failure _ -> ()

    result