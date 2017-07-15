module HtmlParser

open System.Text.RegularExpressions

let GetTabContentFromHtml html =
    Regex
        .Match(html, ".*js-tab-content js-copy-content\">(.*)</pre>.*", RegexOptions.Singleline)
        .Groups.[1]
        .Value

let GetChordsFromTab tabContent =
    Regex.Matches(tabContent, "(<span>)((\S)+?)(</span>)")
    |> Seq.cast<Match>
    |> Seq.map (fun m -> m.Groups.[2].Value)

let GetChords html = 
    html
    |> GetTabContentFromHtml 
    |> GetChordsFromTab
