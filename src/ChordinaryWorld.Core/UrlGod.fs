module UrlGod

open System
open System.Text.RegularExpressions

let HandlePunctuation (s: string) =
    s
    |> fun s -> Regex.Replace(s, ",|/|\.", " ")
    |> fun s -> Regex.Replace(s, "\?|!|\(|\)|'", "")

let HandleSpaces (s: string) =
    Regex.Replace(s, "\s+", "_")

let FormatForUG(s: string) =
    s
    |> HandlePunctuation
    |> HandleSpaces
    |> fun s -> s.ToLower()

let ComposeUGUrl (artist: string, title: string) = 
    let firstLetter = artist.[0]
    String.Format(
        "https://tabs.ultimate-guitar.com/{0}/{1}/{2}_crd.htm",
        firstLetter, artist, title)

let MakeUrl (artist: string, title: string) =
    (FormatForUG artist, FormatForUG title)
    |> ComposeUGUrl