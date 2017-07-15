module CoreTests

open Xunit

[<Fact>]
let GetsThreeChordsForKino() = 
    let song = ("kino", "pachka sigaret")
    let expected = 3

    let actual = Core.GetNumberOfChords song

    Assert.Equal(expected, actual.Value)

[<Theory>]
[<InlineData("Glass Animals", "Life Itself", 6)>]
[<InlineData("Imagine Dragons", "Radioactive", 4)>]
[<InlineData("Royal Blood", "Lights Out", 9)>]
[<InlineData("Glass Animals", "Youth", 4)>]
[<InlineData("Arcade Fire", "The Suburbs", 5)>]
[<InlineData("The Jesus And Mary Chain", "About You", 4)>]
[<InlineData("Glass Animals", "Black Mambo", 5)>]
[<InlineData("Slowdive", "Star Roving", 6)>]
[<InlineData("Queen", "Crazy Little Thing Called Love", 7)>]
[<InlineData("Glass Animals", "Pork Soda", 7)>]
let GetNumberOfChordsForNormalSongs(artist, title, numberOfChords) =
    let expected = numberOfChords

    let actual = Core.GetNumberOfChords (artist, title)

    Assert.Equal(expected, actual.Value)

[<Fact>]
let HandlesNotFoundSong() =
    let song = ("Nothing But Thieves", "Ban All The Music")

    let result = Core.GetNumberOfChords song

    Assert.True(result.IsNone)