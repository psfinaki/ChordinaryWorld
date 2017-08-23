module TabMasterTests

open Xunit
open TabMaster

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

[<Fact>]
let HandlesNoTabs() = 
    let song = Song.Create("unknown", "song")
    let expected = ChordsNotFound
    
    let actual = song |> GetTab |> ExtractFailure

    Assert.Equal(expected, actual)