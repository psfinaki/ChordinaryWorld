module CrawlerTests

open Xunit
open Crawler

[<Theory>]
[<InlineData("tycho", "awake", 0)>]
[<InlineData("alt-j", "adeline", 1)>]
[<InlineData("portishead", "roads", 3)>]
[<InlineData("lou reed", "walk on the wild side", 5)>]
let GetsTabs artist title numberOfTabs = 
    let expected = numberOfTabs
    
    let actual = (artist, title) |> GetTabs |> Seq.length 

    Assert.Equal(expected, actual)

[<Fact>]
let GetsVariationsCommon() =
    let s = "fire"
    let expected = [ "fire" ]

    let actual = GetVariations s

    Assert.Equal(expected, actual)

[<Fact>]
let GetsVariationsAmpersand() =
    let s = "metal & dust"
    let expected = [ "metal and dust"; "metal dust" ]

    let actual = GetVariations s

    Assert.Equal(expected, actual)

[<Fact>]
let GetsVariationsPlus() =
    let s = "florence + the machine"
    let expected = [ "florence and the machine"; "florence the machine" ]

    let actual = GetVariations s

    Assert.Equal(expected, actual)