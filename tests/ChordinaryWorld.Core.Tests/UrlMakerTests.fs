module UrlMakerTests

open System
open Xunit
open UrlMaker

[<Fact>]
let MakesUrlForFirstVersion() = 
    let artist = "kasabian"
    let title = "underdog"
    let version = 1
    let expected = "https://tabs.ultimate-guitar.com/k/kasabian/underdog_crd.htm"
    
    let actual = MakeUrl (artist, title, version)

    Assert.Equal(expected, actual)

[<Fact>]
let MakesUrlForNotFirstVersion() = 
    let artist = "kasabian"
    let title = "underdog"
    let version = 2
    let expected = "https://tabs.ultimate-guitar.com/k/kasabian/underdog_ver2_crd.htm"
    
    let actual = MakeUrl (artist, title, version)

    Assert.Equal(expected, actual)

[<Fact>]
let ThrowsForInvalidVersion() = 
    let artist = "kasabian"
    let title = "underdog"
    let version = 0
    
    let action = fun () -> MakeUrl (artist, title, version) |> ignore

    Assert.Throws<ArgumentException> action