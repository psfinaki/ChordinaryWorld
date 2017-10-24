module GetTopTests

open Xunit
open Core

[<Fact>]
let GetsTop() =
    let expected =
        [
            "Queen", "Bohemian Rhapsody", 24
        ]

    let actual = 1 |> GetTop |> ExtractSuccess

    Assert.Equal<'T list>(expected, actual)

[<Fact>]
let HandlesNegativeCount() =
    let expected = NegativeCount

    let actual = -42 |> GetTop |> ExtractFailure

    Assert.Equal(expected, actual)

[<Fact>]
let HandlesTooBigCount() =
    let expected = TooBigCount
    
    let actual = 1000 |> GetTop |> ExtractFailure

    Assert.Equal(expected, actual)

