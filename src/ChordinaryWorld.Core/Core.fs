module Core

open Result
open AbstractOperations

let GetNumberOfHarmonies song =
    if fst song = "kino"
    then
        Success 3
    else
        song
        |> Validator.ValidateSong
        |> map Canonicalizer.CanonicalizeSong
        |> bind Crawler.GetTab
        |> map HtmlParser.GetChords
        |> bind Engine.GetNumberOfHarmonies
