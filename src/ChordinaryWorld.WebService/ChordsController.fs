module ChordsController

open System.Web.Http

type ChordsController() =
    inherit ApiController()

    member x.Get(artist, title) =
        let Unnullify s = if s = null then "" else s 

        let result = 
            (Unnullify artist, Unnullify title)
            |> Core.GetNumberOfHarmonies

        match result with
        | Success x -> 
            x
        | Failure error ->
            match error with
            | ChordsNotFound -> -1
            | EmptyInput -> -2
            | UnknownFlavour -> -3
