module Sieve

let RemoveSuspends (chords: seq<string>) =
    chords
    |> Seq.filter (fun c -> not (c.Contains("sus")))

let RemovePowers (chords: seq<string>) =
    chords 
    |> Seq.filter (fun c -> snd (Analyzer.AnalyzeChord(c)) <> "5")
