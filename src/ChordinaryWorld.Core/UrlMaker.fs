module UrlMaker

open System

let MakeUrl (artist: string, title: string) =
    let firstLetter = artist.[0]
    String.Format(
        "https://tabs.ultimate-guitar.com/{0}/{1}/{2}_crd.htm",
        firstLetter, artist, title)