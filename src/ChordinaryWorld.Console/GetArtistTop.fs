module GetArtistTop

open System

let GetArtist() = 
    printfn "Enter artist"
    Console.ReadLine()

let PrintTop top = 
    printfn "Here is the top:"
    top |> Seq.iter (printfn "%A")

let TranslateError = function
    | BadArtist ->
        "Invalid artist"

let Play() =
    Features.PlayFeature
        Core.GetArtistTop
        GetArtist
        PrintTop
        TranslateError
        (fun (_) -> "")
