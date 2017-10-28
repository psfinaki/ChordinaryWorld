module ArtistTopMasterTests

open Xunit
open ArtistTopMaster

[<Fact>]
let GetsTopSongsMoreThan3() =
    let top =
        [
            ("Muse", "Showbiz"), 6
            ("Muse", "Sunburn"), 10
            ("Muse", "Unintended"), 7
            ("Muse", "Escape"), 9
        ]

    let expected = 
        [
            "Sunburn", 10
            "Escape", 9
            "Unintended", 7
        ]
        
    let actual = GetTopSongsMax3 top

    Assert.Equal(expected, actual)

[<Fact>]
let GetsTopSongs3() =
    let top =
        [
            ("Muse", "Sunburn"), 10
            ("Muse", "Unintended"), 7
            ("Muse", "Escape"), 9
        ]

    let expected = 
        [
            "Sunburn", 10
            "Escape", 9
            "Unintended", 7
        ]
        
    let actual = GetTopSongsMax3 top

    Assert.Equal(expected, actual)

[<Fact>]
let GetsTopSongsLessThan3() =
    let top =
        [
            ("Muse", "Sunburn"), 10
            ("Muse", "Unintended"), 7
        ]

    let expected = 
        [
            "Sunburn", 10
            "Unintended", 7
        ]
        
    let actual = GetTopSongsMax3 top

    Assert.Equal(expected, actual)        