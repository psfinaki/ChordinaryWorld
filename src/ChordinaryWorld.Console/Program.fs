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
        | Some(x) -> 
            printfn "Number of harmonies here is %A" x
        | None -> 
            printfn "Chords to this song cannot be retrieved"

        Console.WriteLine()
    0
