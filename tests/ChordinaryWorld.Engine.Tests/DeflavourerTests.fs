﻿module DeflavourerTests

open System
open System.Collections.Generic
open Xunit
open Deflavourer

[<Theory>]
[<InlineData("A", "A")>]
[<InlineData("A#6", "A#")>]
[<InlineData("B6", "B")>]
[<InlineData("C7", "C")>]
[<InlineData("Dm", "Dm")>]
[<InlineData("D#m6", "D#m")>]
[<InlineData("Em7", "Em")>]
[<InlineData("Fm9", "Fm")>]
[<InlineData("Gaug", "Gaug")>]
[<InlineData("G#dim", "G#dim")>]
let DeflavoursChord chord deflavoured =
    let expected = deflavoured

    let actual = DeflavourChord chord

    Assert.Equal(expected, actual)

[<Fact>]
let ThrowsForUnknownFlavour() =
    let chord = "F#UNKNOWN"
    
    let action = fun () -> DeflavourChord chord |> ignore

    Assert.Throws<KeyNotFoundException> action

[<Fact>]
let Deflavours() =
    let chords = ["E"; "E7"; "Dm"; "Dadd9"]
    let expected = ["E"; "Dm"; "D"]

    let actual = chords |> Deflavour |> ExtractSuccess

    Assert.Equal(expected, actual)

[<Fact>]
let HandlesUnknownFlavours() =
    let chords = ["E"; "F#Weird"; "Dm"; "BbmWrong"]
    let expected = UnknownFlavour

    let actual = chords |> Deflavour |> ExtractFailure

    Assert.Equal(expected, actual)

[<Fact>]
let ThrowsForNotAChord() =
    let chord = "Random"

    let action = fun () -> DeflavourChord chord |> ignore
    
    Assert.Throws<ArgumentException> action
