module Formatter

open System
open System.Text.RegularExpressions

let Preformat(s: string) =
    s
     .Trim()
     .ToLower()

let HandlePunctuation (s: string) =
    s
    |> fun s -> Regex.Replace(s, ",|/|\.", " ")
    |> fun s -> Regex.Replace(s, "\?|!|\(|\)|'", "")

let HandleSpaces (s: string) =
    Regex.Replace(s, "\s+", "_")

let Format(s: string) =
    s
    |> Preformat
    |> HandlePunctuation
    |> HandleSpaces

let FormatSong (artist: string, title: string) =
    (Format artist, Format title)
