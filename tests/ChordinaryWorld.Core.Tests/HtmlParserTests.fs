module HtmlParserTests

open Xunit

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

    let actual = HtmlParser.GetRating html

    Assert.Equal(expected, actual)

[<Fact>]
let GetsBigRating() =
    let html = "<span><span itemprop=\"ratingCount\">1,024</span></span>"
    let expected = 1024

    let actual = HtmlParser.GetRating html

    Assert.Equal(expected, actual)

[<Fact>]
let HandlesAbsentRating() =
    let html = "<div></div>"
    let expected = 0

    let actual = HtmlParser.GetRating html

    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData("A")>]
[<InlineData("B")>]
[<InlineData("C")>]
[<InlineData("D")>]
[<InlineData("E")>]
[<InlineData("F")>]
[<InlineData("G")>]
[<InlineData("H")>]
[<InlineData("Amaj")>]
[<InlineData("A6")>]
[<InlineData("A7")>]
[<InlineData("Aadd9")>]
[<InlineData("A2")>]
[<InlineData("AM")>]
[<InlineData("A7b9")>]
[<InlineData("A9")>]
[<InlineData("Amaj9")>]
[<InlineData("A7#9")>]
[<InlineData("A11")>]
[<InlineData("C#")>]
[<InlineData("C#m")>]
[<InlineData("C#min")>]
[<InlineData("C#m6")>]
[<InlineData("C#m7")>]
[<InlineData("C#mM7")>]
[<InlineData("C#m9")>]
[<InlineData("C#m11")>]
[<InlineData("Ebaug")>]
[<InlineData("Eb7#5")>]
[<InlineData("Eb9#5")>]
[<InlineData("Ebdim")>]
[<InlineData("Ebdim7")>]
[<InlineData("Ebm7b5")>]
[<InlineData("F5")>]
[<InlineData("Fsus2")>]
[<InlineData("Fsus4")>]
[<InlineData("Fsus2sus4")>]
[<InlineData("D/G")>]
let RecognizesChord(s) =
    let result = HtmlParser.IsChord s

    Assert.True(result)
    
[<Theory>]
[<InlineData("")>]
[<InlineData("Tab Pro")>]
[<InlineData("History")>]
[<InlineData("I")>]
[<InlineData("D/")>]
[<InlineData("D/R")>]
[<InlineData("D/7")>]
[<InlineData("42")>]
let RecognizesNotChord(s) =
    let result = HtmlParser.IsChord s

    Assert.False(result)