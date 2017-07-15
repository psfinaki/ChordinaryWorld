module EngineTests

open Xunit

[<Fact>]
let GetsNumberOfChords() =
    let chords = ["Am"; "Dm"; "Em"]
    let expected = 3

    let actual = Engine.GetNumberOfChords chords

    Assert.Equal(expected, actual)

[<Fact>]
let GetsNumberOfChordsWhenDuplicates() =
    let chords = ["Am"; "Dm"; "Em"; "Dm"]
    let expected = 3

    let actual = Engine.GetNumberOfChords chords

    Assert.Equal(expected, actual)

[<Fact>]
let GetsNumberOfChordsWhenFlavours() =
    let chords = ["A"; "Amaj7"; "D"; "E"; "Bm"]
    let expected = 4

    let actual = Engine.GetNumberOfChords chords

    Assert.Equal(expected, actual)