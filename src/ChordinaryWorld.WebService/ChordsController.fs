module ChordsController

open System.Web.Http
open Result

type ChordsController() =
    inherit ApiController()

    member x.Get(artist: string, title: string) =
        let result = 
            (artist, title)
            |> Core.GetNumberOfHarmonies

        match result with
        | Success(x) -> 
            x
        | Failure(error) ->
            match error with
            | ChordsNotFound -> -1
