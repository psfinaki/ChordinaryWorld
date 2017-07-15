module UrlGodTests

open Xunit

[<Fact>]
let MakesUrl() =
    let song = ("the decemberists", "raincoat song")

    let result = UrlGod.MakeUrl song
    let resultIsUrl = result.StartsWith "http"

    Assert.True(resultIsUrl)

[<Theory>]
[<InlineData("the decemberists", "raincoat song")>]
[<InlineData("The Decemberists", "Raincoat Song")>]
[<InlineData("The decemberists", "Raincoat song")>]
[<InlineData("The decemberists", "raincoat song")>]
let MakesCorrectUrl(artist, title) =
    let song = (artist, title)
    let expected = "https://tabs.ultimate-guitar.com/t/the_decemberists/raincoat_song_crd.htm"

    let actual = UrlGod.MakeUrl song

    Assert.Equal(expected, actual)
