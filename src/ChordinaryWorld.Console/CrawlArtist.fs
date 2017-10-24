module CrawlArtist

open System

let GetArtist() = 
    printfn "Enter artist"
    Console.ReadLine()

let Play() =
    Features.PlayFeature
        (Crawler.CrawlArtist >> succeed)
        GetArtist
        (fun () -> ())
        (fun () -> "")
        (fun () -> "")
