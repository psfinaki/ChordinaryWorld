module internal HtmlParser

open System.Text.RegularExpressions
open System
open System.Globalization

let IsChord s =
    let note = "[ABCDEFG]{1}?[#b]?"
    let flavour = "[a-zA-Z0-9#+-]{0,10}"
    let variation = "(/" + note + ")?"
    let pattern = "^(" + note + flavour + variation + ")$"
    Regex.IsMatch(s, pattern)

let GetRating html =
    let m = Regex.Match(html, "<span itemprop=\"ratingCount\">(.*?)</span>")
    
    match m.Success with
    | true ->
        let rating = m.Groups.[1].Value
        Int32.Parse(rating, NumberStyles.AllowThousands)
    | false -> 
        0

let GetChords html = 
    let m = Regex.Matches(html, "<span>(\S+?)</span>")

    m
    |> Seq.cast<Match>
    |> Seq.map (fun m -> m.Groups.[1].Value)
    |> Seq.filter IsChord