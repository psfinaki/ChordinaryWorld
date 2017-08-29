module SieveTests

open Xunit
open Sieve

[<Theory>]
[<InlineData("Asus2")>]
[<InlineData("Bsus4")>]
[<InlineData("Bsus2sus4")>]
let RecognizesSuspend chord =
    let result = IsSuspend chord

    Assert.True(result)

[<Theory>]
[<InlineData("A")>]
[<InlineData("B5")>]
[<InlineData("Cm")>]
let RecognizesNotSuspend chord =
    let result = IsSuspend chord

    Assert.False(result)

[<Fact>]
let RecognizesPower() =
    let chord = "A5"
    let result = IsPower chord

    Assert.True(result)

[<Fact>]
let RecognizesNotPower() =
    let chord = "A"
    let result = IsPower chord

    Assert.False(result)

[<Theory>]
[<InlineData("A")>]
[<InlineData("Bm")>]
let RecognizesCommon chord =
    let result = IsCommon chord

    Assert.True(result)

[<Theory>]
[<InlineData("Asus2")>]
[<InlineData("B5")>]
let RecognizesNotCommon chord =
    let result = IsCommon chord

    Assert.False(result)

[<Fact>]
let GetsChordsOnTonic() =
    let chords = [ "A7"; "A"; "B" ]
    let tonic = "A"
    let expected = [ "A7"; "A" ]

    let actual = GetChordsOnTonic chords tonic

    Assert.Equal(expected, actual)

[<Fact>]
let RecognizesFriends() =
    let chords = [ "A"; "C" ]
    let chord = "Asus2"

    let result = HasFriends chords chord

    Assert.True(result)

[<Fact>]
let RecognizesNoFriends() =
    let chords = [ "A"; "C" ]
    let chord = "Bsus2"

    let result = HasFriends chords chord

    Assert.False(result)

[<Fact>]
let RemovesNotLonelySuspend() =
    let chords = [ "Asus2"; "A" ]
    let expected = [ "A" ]

    let actual = FilterSuspends chords

    Assert.Equal(expected, actual)

[<Fact>]
let PreservesLonelySuspend() =
    let chords = [ "Asus2"; "D" ]
    let expected = [ "Asus2"; "D" ]

    let actual = FilterSuspends chords

    Assert.Equal(expected, actual)

[<Fact>]
let RemovesNotLonelyPowers() =
    let chords = [ "E5"; "E" ]
    let expected = [ "E" ]

    let actual = FilterPowers chords

    Assert.Equal(expected, actual)
    
[<Fact>]
let PreservesLonelyPowers() =
    let chords = [ "E5"; "D" ]
    let expected = [ "E5"; "D" ]

    let actual = FilterPowers chords

    Assert.Equal(expected, actual)

[<Fact>]
let Sifts() =
    let chords = ["E"; "Esus2"; "E5"; "Fsus4"; "G5" ]
    let expected = ["E"; "Fsus4"; "G5" ]

    let actual = Sift chords

    Assert.Equal(expected, actual)