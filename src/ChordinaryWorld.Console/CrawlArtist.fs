module CrawlArtist

open System

let GetArtist() = 
    printfn "Enter artist"
    Console.ReadLine()

let Play() =
    Features.PlayFeature
        (Core.GetArtistTop >> succeed)
        GetArtist
        (fun (_) -> ())
        (fun () -> "")
        (fun () -> "")
