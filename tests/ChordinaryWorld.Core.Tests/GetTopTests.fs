module GetTopTests

open Xunit
open Core

[<Fact>]
let GetsTop() =
    let expected =
        [
            "Queen", "Bohemian Rhapsody", 24
        ]

    let actual = GetTop 1 |> ExtractSuccess

    Assert.Equal<'T list>(expected, actual)

[<Fact>]
let HandlesNegativeCount() =
    let expected = ExternalError NegativeCount

    let actual = -42 |> GetTop |> ExtractFailure

    Assert.Equal(expected, actual)

[<Fact>]
let HandlesBadCount() =
    let expected = InternalError UnknownDatabaseError
    
    let actual = 1000 |> GetTop |> ExtractFailure

    Assert.Equal(expected, actual)

