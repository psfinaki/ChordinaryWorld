module CanonicalizerTests

open Xunit
open Canonicalizer

[<Fact>]
let CanonicalizesSong() =
    let song = ("LP", "lost on you")
    let expected = ("lp", "lost_on_you")

    let actual = CanonicalizeSong song

    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData("Proactive Evolution")>]
[<InlineData("proactive evolution")>]
[<InlineData("  proactive evolution")>]
[<InlineData("proactive evolution ")>]
[<InlineData(" proactive evolution  ")>]
let Preformats input =
    let expected = "proactive evolution"

    let actual = Preformat input

    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData("pork,soda")>]
[<InlineData("pork/soda")>]
[<InlineData("pork.soda")>]
let HandlesPunctuationToSpace input =
    let expected = "pork soda"

    let actual = HandlePunctuation input

    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData("porksoda")>]
[<InlineData("pork?soda")>]
[<InlineData("pork!soda")>]
[<InlineData("pork(soda")>]
[<InlineData("pork)soda")>]
[<InlineData("pork()soda")>]
[<InlineData("pork'soda")>]
let HandlesPunctuationToEmpty input =
    let expected = "porksoda"

    let actual = HandlePunctuation input

    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData("god is an astronaut")>]
[<InlineData("god  is  an astronaut")>]
let HandlesSpaces urlPart =
    let expected = "god_is_an_astronaut"

    let actual = HandleSpaces urlPart

    Assert.Equal(expected, actual)