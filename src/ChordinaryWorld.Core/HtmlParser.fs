module HtmlParser

open System.Text.RegularExpressions
open System
open System.Globalization

let GetTabContentFromHtml html =
    Regex
        .Match(html, ".*js-tab-content js-copy-content\">(.*)</pre>.*", RegexOptions.Singleline)
        .Groups.[1]
        .Value

let GetRatingFromHtml html =
    let m = Regex.Match(html, "<span itemprop=\"ratingCount\">(.*?)</span>")
    
    match m.Success with
    | true ->
        let rating = m.Groups.[1].Value
        Int32.Parse(rating, NumberStyles.AllowThousands)
    | false -> 
        0

let GetChordsFromTab tabContent =
    Regex.Matches(tabContent, "<span>(\S+?)</span>")
    |> Seq.cast<Match>
    |> Seq.map (fun m -> m.Groups.[1].Value)

let GetChords html = 
    html
    |> GetTabContentFromHtml 
    |> GetChordsFromTab
