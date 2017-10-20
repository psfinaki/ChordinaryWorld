﻿module TopController

open System.Web.Http

type TopController() =
    inherit ApiController()

    member x.Get count =
        let result = Core.GetTop count

        match result with
        | Success (top,_) ->
            x.Ok top
            :> IHttpActionResult
        | Failure error ->
            match error with
            | InternalError _ ->
                x.InternalServerError()
                :> IHttpActionResult
            | ExternalError _ ->
                x.BadRequest()
                :> IHttpActionResult