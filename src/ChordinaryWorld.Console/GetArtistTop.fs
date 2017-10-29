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
    | NoTabsFound ->
        "Looks like nobody writes chords for this artist"
    | TabsUnavailable ->
        "Cannot reach chord provider"
    | BadTabs ->
        "All found tabs have problems"

let Play() =
    Features.PlayFeature
        Core.GetArtistTop
        GetArtist
        PrintTop
        TranslateError
        (fun (_) -> "")
