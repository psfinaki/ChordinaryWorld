module internal Features

open System

let GetInput() =
    printfn "Enter the artist"
    let artist = Console.ReadLine()
    printfn "Enter the title"
    let title = Console.ReadLine()
    (artist, title)

let TranslateWarning = function 
    | UnknownDatabaseIssue -> 
        "Something bad happened in database"

let TranslateError = function
    | ChordsNotFound -> 
        "Chords are not found"
    | EmptyInput -> 
        "Empty input is not allowed"
    | UnknownFlavours x -> 
        "Unknown flavours in the tab: " + (Seq.toList x).ToString()

let GetNumberOfHarmonies() =
    let result = Core.GetNumberOfHarmonies <| GetInput()

    match result with
    | Success (x, warnings) -> 
        printfn "Number of harmonies here is %A" x

        warnings 
        |> Seq.map TranslateWarning 
        |> Seq.iter Console.WriteLine

    | Failure error -> 
        error 
        |> TranslateError 
        |> Console.WriteLine

let GetTop() =
    printfn "Enter top count"
    let input = Console.ReadLine()

    let result = Core.GetTop <| Int32.Parse input
    match result with
    | Success (top, warnings) ->
        printfn "Here is the top:"
        top |> Seq.iter (printfn "%A")

        warnings 
        |> Seq.map TranslateWarning 
        |> Seq.iter Console.WriteLine
    | Failure error ->
        error 
        |> TranslateWarning
        |> Console.WriteLine
