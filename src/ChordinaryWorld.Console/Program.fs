open System
open Result

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
        | Success x -> 
            printfn "Number of harmonies here is %A" x
        | Failure error -> 
            match error with
            | ChordsNotFound -> 
                printfn "Chords are not found"
            | EmptyInput ->
                printfn "Empty input is not allowed"
            | UnknownFlavour ->
                printfn "Unknown chord in the tab"

        Console.WriteLine()
    0
