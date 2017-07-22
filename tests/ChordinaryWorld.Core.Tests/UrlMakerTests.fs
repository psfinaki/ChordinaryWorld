module UrlMakerTests

open Xunit

[<Fact>]
let ComposesUGUrl = 
    let song = ("kasabian", "underdog")
    let expected = "https://tabs.ultimate-guitar.com/k/kasabian/underdog_crd.htm"
    
    let actual = UrlMaker.MakeUrl song

    Assert.Equal(expected, actual)
