module UrlGodTests

open Xunit

[<Fact>]
let MakesUrl() =
    let song = ("The Doors", "Hello, I Love You")
    let expected = "https://tabs.ultimate-guitar.com/t/the_doors/hello_i_love_you_crd.htm"

    let actual = UrlGod.MakeUrl song

    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData("pork,soda")>]
[<InlineData("pork/soda")>]
[<InlineData("pork.soda")>]
let HandlesPunctuationToSpace(input) =
    let expected = "pork soda"

    let actual = UrlGod.HandlePunctuation input

    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData("porksoda")>]
[<InlineData("pork?soda")>]
[<InlineData("pork!soda")>]
[<InlineData("pork(soda")>]
[<InlineData("pork)soda")>]
[<InlineData("pork()soda")>]
[<InlineData("pork'soda")>]
let HandlesPunctuationToEmpty(input) =
    let expected = "porksoda"

    let actual = UrlGod.HandlePunctuation input

    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData("god is an astronaut")>]
[<InlineData("god  is  an astronaut")>]
let HandlesSpaces(urlPart) =
    let expected = "god_is_an_astronaut"

    let actual = UrlGod.HandleSpaces urlPart

    Assert.Equal(expected, actual)

[<Fact>]
let ComposesUGUrl = 
    let song = ("kasabian", "underdog")
    let expected = "https://tabs.ultimate-guitar.com/k/kasabian/underdog_crd.htm"
    
    let actual = UrlGod.ComposeUGUrl song

    Assert.Equal(expected, actual)
