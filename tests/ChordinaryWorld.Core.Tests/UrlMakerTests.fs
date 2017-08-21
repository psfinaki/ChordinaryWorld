module UrlMakerTests

open System
open Xunit
open UrlMaker

[<Fact>]
let MakesUrlForFirstVersion() = 
    let song = Song.Create("kasabian", "underdog")
    let version = 1
    let expected = "https://tabs.ultimate-guitar.com/k/kasabian/underdog_crd.htm"
    
    let actual = MakeUrl version song

    Assert.Equal(expected, actual)

[<Fact>]
let MakesUrlForNotFirstVersion() = 
    let song = Song.Create("kasabian", "underdog")
    let version = 2
    let expected = "https://tabs.ultimate-guitar.com/k/kasabian/underdog_ver2_crd.htm"
    
    let actual = MakeUrl version song

    Assert.Equal(expected, actual)

[<Fact>]
let ThrowsForInvalidVersion() = 
    let song = Song.Create("kasabian", "underdog")
    let version = 0
    
    let action = fun () -> MakeUrl version song |> ignore

    Assert.Throws<ArgumentException> action