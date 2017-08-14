module DeslasherTests

open Xunit
open Deslasher

[<Fact>]
let Deslashes() =
    let chords = ["E"; "E/G"; "D7/Hsus2"]
    let expected = ["E"; "D7"]

    let actual = Deslash chords

    Assert.Equal(expected, actual)
    
[<Theory>]
[<InlineData("D/E", "D")>]
[<InlineData("A", "A")>]
[<InlineData("C7", "C7")>]
let DeslashesChord chord deslashed =
    let expected = deslashed
    
    let actual = DeslashChord chord

    Assert.Equal(expected, actual)

