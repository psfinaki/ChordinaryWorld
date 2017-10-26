module GetArtistTop

open System

let GetArtist() = 
    printfn "Enter artist"
    Console.ReadLine()

let PrintTop = printfn "%A"

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
