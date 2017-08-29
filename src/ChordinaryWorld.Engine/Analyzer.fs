module internal Analyzer

open System.Text.RegularExpressions

let AnalyzeChord chord =
    let regex = "([ABCDEFG]{1}[#b]?)(.*)"
    let m = Regex.Match(chord, regex)

    match m.Success with
    | false -> 
        invalidArg "chord" "chord must start with letter form A-G diapason"
    | true ->
        let tonic = m.Groups.[1].Value
        let flavour = m.Groups.[2].Value
        (tonic, flavour)

let GetTonic chord = fst (AnalyzeChord chord)

