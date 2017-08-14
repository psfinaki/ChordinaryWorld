module CrawlerTests

open Xunit
open Crawler

[<Theory>]
[<InlineData("tycho", "awake", 0)>]
[<InlineData("alt-j", "adeline", 1)>]
[<InlineData("portishead", "roads", 3)>]
let GetsTabs artist title numberOfTabs = 
    let expected = numberOfTabs
    
    let actual = (artist, title) |> GetTabs |> Seq.length 

    Assert.Equal(expected, actual)