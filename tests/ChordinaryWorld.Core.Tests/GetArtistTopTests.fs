module GetArtistTopTests

open Xunit
open Core

[<Fact>]
let GetsArtistTop() =
    let artist = "muse"
    let expected = ("Knights of Cydonia", 13)

    let actual = GetArtistTop artist

    Assert.Equal(expected, actual)
