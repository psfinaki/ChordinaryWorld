module GetArtistTopTests

open Xunit
open Core

[<Fact>]
let GetsArtistTop() =
    let artist = "muse"
    let expected = 
        [
            ("Knights of Cydonia", 13);
            ("Time Is Running Out", 8);
            ("Starlight", 7)
        ]

    let actual = GetArtistTop artist |> ExtractSuccess

    Assert.Equal(expected, actual)

[<Fact>]
let HandlesBadArtist() =
    let artist = "the band that does not exist 42"
    let expected = BadArtist

    let actual = GetArtistTop artist |> ExtractFailure

    Assert.Equal(expected, actual)

[<Fact>]
let HandlesArtistWithLittleTabs() =
    let artist = "justice"
    let expected = 
        [
            ("DVNO", 5)
        ]

    let actual = GetArtistTop artist |> ExtractSuccess

    Assert.Equal(expected, actual)

[<Fact>]
let HandlesArtistWithNoTabs() =
    let artist = "Ololo"
    let expected = NoTabsFound

    let actual = GetArtistTop artist |> ExtractFailure

    Assert.Equal(expected, actual)
