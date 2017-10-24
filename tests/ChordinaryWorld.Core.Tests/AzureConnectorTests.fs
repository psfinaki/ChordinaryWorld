module AzureConnectorTests

open Xunit
open AzureConnector

[<Fact>]
let HandlesNegativeCount() =
    let expected = NegativeCount
    
    let actual = -42 |> GetTop |> ExtractFailure

    Assert.Equal(expected, actual)

[<Fact>]
let HandlesTooBigCount() =
    let expected = TooBigCount
    
    let actual = 10000 |> GetTop |> ExtractFailure

    Assert.Equal(expected, actual)
