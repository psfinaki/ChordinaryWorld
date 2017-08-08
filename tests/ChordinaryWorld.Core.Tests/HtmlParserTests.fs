module HtmlParserTests

open Xunit

[<Theory>]
[<InlineData("<span>Am</span>            <span>Dm</span>")>]
[<InlineData("<span>Am</span><span>Dm</span>")>]
let GetsChordsFromTab(tabContent) =
    let expected = [ "Am"; "Dm" ]

    let actual = HtmlParser.GetChordsFromTab tabContent

    Assert.Equal(expected, actual)

[<Fact>]
let GetsTabContentFromHtml() =
    let html = "<html><b></b><pre class=\"js-tab-content js-copy-content js-tab-controls-item\" style=\"position: relative\">tab content</pre></html>"
    let expected = "tab content"

    let actual = HtmlParser.GetTabContentFromHtml html

    Assert.Equal(expected, actual)

[<Fact>]
let GetsTabContentWithNewlinesFromHtml() =
    let html = "<html><b></b><pre class=\"js-tab-content js-copy-content js-tab-controls-item\" style=\"position: relative\">tab\ncontent</pre></html>"
    let expected = "tab\ncontent"

    let actual = HtmlParser.GetTabContentFromHtml html

    Assert.Equal(expected, actual)

[<Fact>]
let GetsChords() =
    let html = "<html><b></b><pre class=\"js-tab-content js-copy-content js-tab-controls-item\" style=\"position: relative\"><span>Am</span><span>Dm</span><span>Am</span></pre></html>"
    let expected = [ "Am"; "Dm"; "Am" ]

    let actual = HtmlParser.GetChords html

    Assert.Equal(expected, actual)

[<Fact>]
let GetsSmallRating() =
    let html = "<span><span itemprop=\"ratingCount\">42</span></span>"
    let expected = 42

    let actual = HtmlParser.GetRatingFromHtml html

    Assert.Equal(expected, actual)

[<Fact>]
let GetsBigRating() =
    let html = "<span><span itemprop=\"ratingCount\">1,024</span></span>"
    let expected = 1024

    let actual = HtmlParser.GetRatingFromHtml html

    Assert.Equal(expected, actual)

[<Fact>]
let HandlesAbsentRating() =
    let html = "<div></div>"
    let expected = 0

    let actual = HtmlParser.GetRatingFromHtml html

    Assert.Equal(expected, actual)

