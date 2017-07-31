module UrlMaker

open System

let MakeUrl (artist: string, title: string, version: int) =
    let firstLetter = artist.[0]

    match version with
    | i when i <= 0 ->
        invalidArg "version" "version cannot be less than one"
    | 1 -> 
        String.Format("https://tabs.ultimate-guitar.com/{0}/{1}/{2}_crd.htm", 
                        firstLetter, artist, title)
    | x -> 
        String.Format("https://tabs.ultimate-guitar.com/{0}/{1}/{2}_ver{3}_crd.htm",
                        firstLetter, artist, title, x)