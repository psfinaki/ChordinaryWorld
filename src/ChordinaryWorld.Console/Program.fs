open System

let ReadData() =
    printfn "Enter the artist"
    let artist = Console.ReadLine()
    printfn "Enter the title"
    let title = Console.ReadLine()
    (artist, title)

[<EntryPoint>]
let main argv = 
    printfn "Welcome to the Chordinary World!"
    printfn ""
    
    while true do
        let result = 
            ReadData()
            |> Core.GetNumberOfHarmonies 

        match result with
        | Success (x, warnings) -> 
            let prettifyWarning = function 
                | UnknownDatabaseIssue -> "Something bad happened in database"
            
            printfn "Number of harmonies here is %A" x
            warnings |> Seq.map prettifyWarning |> Seq.iter Console.WriteLine
        | Failure error -> 
            match error with
            | ChordsNotFound -> 
                printfn "Chords are not found"
            | EmptyInput ->
                printfn "Empty input is not allowed"
            | UnknownFlavours x ->
                printfn "Unknown flavours in the tab: %A" (Seq.toList x)

        Console.WriteLine()
    0
