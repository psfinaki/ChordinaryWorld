module CrawlerTests

open Xunit
open Crawler

[<Fact>]
let GetsTopTracks() =
    let artist = "Radiohead"
    let expected = ["Karma Police"; "Creep"; "Paranoid Android"]

    let actual = GetTopTracks 3 artist |> ExtractSuccess

    Assert.Equal(expected, actual)

[<Fact>]
let GetsTopTracksArtistSeveralWords() =
    let artist = "Glass Animals"
    let expected = ["Gooey"; "Black Mambo"; "Pools"]

    let actual = GetTopTracks 3 artist |> ExtractSuccess

    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData "strangeweirdstuff">]
[<InlineData "">]
let HandlesBadArtist artist =
    let expected = BadArtist

    let actual = GetTopTracks 3 artist |> ExtractFailure

    Assert.Equal(expected, actual)
