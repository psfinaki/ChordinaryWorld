module CoreTests

open Xunit
open Result

[<Fact>]
let GetsThreeHarmoniesForKino() = 
    let song = ("kino", "pachka sigaret")
    let expected = 3

    let actual = song |> Core.GetNumberOfHarmonies |> function | Success x -> x

    Assert.Equal(expected, actual)

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
[<InlineData("The Doors", "Hello, I Love You", 6)>]
[<InlineData("Wham!", "Last Christmas", 4)>]
[<InlineData("OK GO", "Needing/Getting", 7)>]
[<InlineData("R.E.M.", "Losing My Religion", 6)>]
[<InlineData("Therapy?", "Diane", 4)>]
[<InlineData("Radiohead", "Street Spirit (Fade Out)", 3)>]
[<InlineData("Cage The Elephant", "Ain't No Rest For The Wicked", 4)>]
[<InlineData("Keane", "Somewhere Only We Know", 6)>]
let GetsNumberOfHarmoniesForNormalSongs(artist, title, numberOfHarmonies) =
    let expected = numberOfHarmonies

    let song = (artist, title)
    let actual = song |> Core.GetNumberOfHarmonies |> function | Success x -> x

    Assert.Equal(expected, actual)

[<Fact>]
let HandlesNotFoundSong() =
    let song = ("Nothing But Thieves", "Ban All The Music")
    let expected = ChordsNotFound
    
    let actual = song |> Core.GetNumberOfHarmonies |> function | Failure x -> x

    Assert.Equal(expected, actual)
