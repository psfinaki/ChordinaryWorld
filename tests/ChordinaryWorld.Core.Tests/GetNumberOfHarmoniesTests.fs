﻿module CoreTests

open Xunit
open Core

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
[<InlineData("London Grammar", "Metal & Dust", 4)>]
[<InlineData("Florence + The Machine", "Never Let Me Go", 5)>]
[<InlineData("Angus & Julia Stone", "Johnny & June", 2)>]
[<InlineData("Queen", "Bohemian Rhapsody", 24)>]
[<InlineData("Radiohead", "High & Dry", 2)>]
[<InlineData("Metallica", "Enter Sandman", 6)>]
[<InlineData("Oasis", "Wonderwall", 5)>]
[<InlineData("Oasis", "Live Forever", 7)>]
[<InlineData("Oasis", "She's Electric", 8)>]
[<InlineData("Love", "Andmoreagain", 9)>]
[<InlineData("Oasis", "The Masterplan", 6)>]
[<InlineData("Oasis", "Stop Crying Your Heart Out", 7)>]
[<InlineData("Queen", "We Are The Champions", 14)>]
[<InlineData("Oasis", "Sad Song", 7)>]
let GetsNumberOfHarmonies artist title numberOfHarmonies =
    let expected = numberOfHarmonies

    let song = (artist, title)
    let actual = song |> GetNumberOfHarmonies |> ExtractSuccess

    Assert.Equal(expected, actual)

[<Fact>]
let HandlesNotFoundSong() =
    let song = ("Nothing But Thieves", "Ban All The Music")
    let expected = ChordsNotFound
    
    let actual = song |> GetNumberOfHarmonies |> ExtractFailure

    Assert.Equal(expected, actual)
    
[<Fact>]
let HandlesEmptyInput() =
    let song = ("Tender", "")
    let expected = EmptyInput
    
    let actual = song |> GetNumberOfHarmonies |> ExtractFailure

    Assert.Equal(expected, actual)
