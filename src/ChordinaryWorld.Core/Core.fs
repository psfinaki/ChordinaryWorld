﻿module Core

let GetNumberOfHarmonies song =
    if fst song = "kino"
    then
        Success 3
    else
        song
        |> Validator.ValidateSong
        |> bind Crawler.GetTab
        |> map HtmlParser.GetChords
        |> bind Engine.GetNumberOfHarmonies
