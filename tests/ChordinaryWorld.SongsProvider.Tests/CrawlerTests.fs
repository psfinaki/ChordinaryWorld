module CrawlerTests

open Xunit
open Crawler

[<Fact>]
let GetsTopTracks() =
    let expected = ["Karma Police"; "Creep"; "Paranoid Android"]

    let actual = GetTopTracks 3 "Radiohead" 

    Assert.Equal(expected, actual)

