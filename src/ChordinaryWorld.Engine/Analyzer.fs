module internal Analyzer

open FSharp.Text.RegexProvider

type ChordRegex = Regex<"(?<Tonic>[ABCDEFG]{1}[#b]?)(?<Flavour>.*)">

let AnalyzeChord chord =
    let m = ChordRegex().TypedMatch chord

    match m.Success with
    | true ->
        (m.Tonic.Value, m.Flavour.Value)
    | false -> 
        invalidArg "chord" "chord must start with letter from A-G diapason"

let GetTonic chord = fst (AnalyzeChord chord)

