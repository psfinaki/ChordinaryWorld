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
    
    let actual = Song.Create(artist, title) |> GetTabs |> Seq.length 

    Assert.Equal(expected, actual)
