module Canonicalizer

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

let Canonicalize =
    Preformat
    >> HandlePunctuation
    >> HandleSpaces

let CanonicalizeSong (artist, title) =
    (Canonicalize artist, Canonicalize title)
