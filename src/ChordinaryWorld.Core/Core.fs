module Core

open Result
open AbstractOperations

let GetNumberOfHarmonies song =
    if fst song = "kino"
    then
        Success 3
    else
        song
        |> Canonicalizer.CanonicalizeSong
        |> Crawler.GetTab
        |> map HtmlParser.GetChords
        |> map Engine.GetNumberOfHarmonies
