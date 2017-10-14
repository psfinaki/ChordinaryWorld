module internal Features

open System

let TranslateWarning = function 
    | UnknownDatabaseIssue -> 
        "Something bad happened in database"

let TranslateError = function
    | ExternalError error ->
        match error with
        | ChordsNotFound -> 
            "Chords are not found"
        | EmptyInput -> 
            "Empty input is not allowed"
    | InternalError error ->
        match error with
        | UnknownDatabaseError ->
            "Something bad happened in database"
        | UnknownFlavours x ->
            "Unknown flavours in the tab: " + (Seq.toList x).ToString()

let PrintResult print = function
    | Success (value, warnings) -> 
        print value

        warnings 
        |> Seq.map TranslateWarning 
        |> Seq.iter Console.WriteLine

    | Failure error -> 
        error 
        |> TranslateError
        |> Console.WriteLine

let PlayFeature feature inputProvider outputFormatter =
    inputProvider()
    |> feature
    |> PrintResult outputFormatter

let GetNumberOfHarmonies() =
    let getSong() =
        printfn "Enter the artist"
        let artist = Console.ReadLine()
        printfn "Enter the title"
        let title = Console.ReadLine()
        (artist, title)

    let printHarmonies =
        printfn "Number of harmonies here is %A" 

    PlayFeature Core.GetNumberOfHarmonies getSong printHarmonies

let GetTop() =
    let getCount() = 
        printfn "Enter top count"
        int <| Console.ReadLine()

    let printTop top = 
        printfn "Here is the top:"
        top |> Seq.iter (printfn "%A")

    PlayFeature Core.GetTop getCount printTop