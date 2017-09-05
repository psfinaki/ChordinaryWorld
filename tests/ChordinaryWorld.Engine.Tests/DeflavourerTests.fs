module DeflavourerTests

open System
open Xunit
open Deflavourer

let ExtractUnknownFlavours result = 
    result
    |> ExtractFailure 
    |> function | UnknownFlavours x -> x | _ -> failwith "Wrong error"

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

    let actual = chord |> DeflavourChord |> ExtractSuccess

    Assert.Equal(expected, actual)

[<Fact>]
let RetrievesUnknownFlavour() =
    let chord = "F#UNKNOWN"
    let expected = "UNKNOWN"
    
    let actual = chord |> DeflavourChord |> ExtractFailure

    Assert.Equal(expected, actual)

[<Fact>]
let Deflavours() =
    let chords = ["E"; "E7"; "Dm"; "Dadd9"]
    let expected = ["E"; "Dm"; "D"]

    let actual = chords |> Deflavour |> ExtractSuccess

    Assert.Equal(expected, actual)

[<Fact>]
let HandlesUnknownFlavours() =
    let chords = ["E"; "F#Weird"; "Dm"; "BbWrong"]
    let expected = [ "Weird"; "Wrong" ]

    let actual = chords |> Deflavour |> ExtractUnknownFlavours

    Assert.Equal(expected, actual)

[<Fact>]
let HandlesUnknownFlavoursWithDuplicates() =
    let chords = ["E"; "F#Weird"; "Dm"; "BbWrong"; "CWrong"]
    let expected = [ "Weird"; "Wrong" ]

    let actual = chords |> Deflavour |> ExtractUnknownFlavours

    Assert.Equal(expected, actual)

[<Fact>]
let ThrowsForNotAChord() =
    let chord = "Random"

    let action = fun () -> DeflavourChord chord |> ignore
    
    Assert.Throws<ArgumentException> action
