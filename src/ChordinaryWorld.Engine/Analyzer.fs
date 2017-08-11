module Analyzer

open System.Text.RegularExpressions

let AnalyzeChord (chord: string) =
    let regex = "([ABCDEFG]{1}[#b]?)(.*)"
    let groups = Regex.Match(chord, regex).Groups

    let tonic = groups.[1].Value
    let flavour = groups.[2].Value

    (tonic, flavour)
