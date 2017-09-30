module CanonicalizerTests

open Xunit
open Canonicalizer

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

[<Fact>]
let HandlesSpaces() =
    let s = "dirty  old   town"
    let expected = "dirty old town"

    let actual = HandleSpaces s

    Assert.Equal(expected, actual)

[<Fact>]
let HandlesPunctuationToSpace() =
    let s = "needing/getting"
    let expected = "needing getting"

    let actual = HandlePunctuation s

    Assert.Equal(expected, actual)

[<Fact>]
let HandlesPunctuationToEmpty() =
    let s = "therapy?"
    let expected = "therapy"

    let actual = HandlePunctuation s

    Assert.Equal(expected, actual)

[<Fact>]
let Canonicalizes() =
    let s = "  are you   mine?"
    let expected = "are you mine"

    let actual = Canonicalize s

    Assert.Equal(expected, actual)