module ChordsController

open System.Web.Http

type ChordsController() =
    inherit ApiController()

    member x.Get(artist: string, title: string) =
        let result = 
            (artist, title)
            |> Core.GetNumberOfHarmonies

        match result with
        | Some(x) -> x
        | None -> -1
