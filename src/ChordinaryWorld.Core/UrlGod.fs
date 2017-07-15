module UrlGod

open System

let MakeUrl (artist: string, title: string) =
    let firstLetter = artist.[0]

    let Format (s: string) = s.Replace(' ', '_')
    let formattedArtist = Format artist
    let formattedTitle = Format title

    String.Format(
        "https://tabs.ultimate-guitar.com/{0}/{1}/{2}_crd.htm",
        firstLetter, formattedArtist, formattedTitle)
    |> fun (url: string) -> url.ToLower()