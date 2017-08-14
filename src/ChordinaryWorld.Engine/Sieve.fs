module internal Sieve

let RemoveSuspends (chords: seq<string>) =
    chords
    |> Seq.filter (fun c -> not (c.Contains("sus")))

let RemovePowers chords =
    chords 
    |> Seq.filter (fun c -> snd (Analyzer.AnalyzeChord c) <> "5")
