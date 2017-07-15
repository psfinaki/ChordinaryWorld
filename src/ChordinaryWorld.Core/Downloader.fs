﻿module Downloader

open System.Net

let NotFound (x: WebResponse) =
    match x with 
    | :? HttpWebResponse as r when r.StatusCode = HttpStatusCode.NotFound -> 
        true
    | _ -> 
        false

let DownloadHtml (url: string) =
    use client = new WebClient()
    try
        client.DownloadString url
        |> Some
    with
        | :? WebException as ex ->
                 match ex.Response with
                 | r when NotFound(r) -> None
                 | _ -> reraise()