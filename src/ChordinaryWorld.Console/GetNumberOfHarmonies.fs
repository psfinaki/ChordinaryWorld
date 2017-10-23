module internal GetNumberOfHarmonies

open System

let GetSong() =
    printfn "Enter the artist"
    let artist = Console.ReadLine()
    printfn "Enter the title"
    let title = Console.ReadLine()
    (artist, title)

let PrintHarmonies =
    printfn "Number of harmonies here is %A" 

let TranslateError = function
    | ChordsNotFound -> 
        "Chords are not found"
    | EmptyInput -> 
        "Empty input is not allowed"
    | UnknownDatabaseErrorHarmonies ->
        "Something bad happened in database"
    | UnknownFlavours x ->
        "Unknown flavours in the tab: " + (Seq.toList x).ToString()

let TranslateWarning = function 
    | UnknownDatabaseIssue -> 
        "Something bad happened in database"

let Play() =
    Features.PlayFeature 
        Core.GetNumberOfHarmonies 
        GetSong 
        PrintHarmonies 
        TranslateError
        TranslateWarning