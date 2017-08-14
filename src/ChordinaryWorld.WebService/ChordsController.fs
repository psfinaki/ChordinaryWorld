module ChordsController

open System.Web.Http

type ChordsController() =
    inherit ApiController()

    member x.Get(artist, title) =
        let result = 
            (artist, title)
            |> Core.GetNumberOfHarmonies

        match result with
        | Success x -> 
            x
        | Failure error ->
            match error with
            | ChordsNotFound -> -1
            | EmptyInput -> -2
            | UnknownFlavour -> -3
