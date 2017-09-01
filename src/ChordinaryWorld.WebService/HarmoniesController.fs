﻿module ChordsController

open System.Web.Http

type HarmoniesController() =
    inherit ApiController()

    member x.Get(artist, title) =
        let Unnullify s = if s = null then "" else s 

        let result = 
            (Unnullify artist, Unnullify title)
            |> Core.GetNumberOfHarmonies

        match result with
        | Success harmonies -> 
            x.Ok harmonies 
            :> IHttpActionResult
        | Failure message ->
            x.BadRequest(message.ToString())
            :> IHttpActionResult