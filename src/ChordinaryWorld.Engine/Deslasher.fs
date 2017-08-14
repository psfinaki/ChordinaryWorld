module internal Deslasher

let DeslashChord (chord: string) =
    chord.IndexOf('/')
    |> fun i -> match i with
                | -1 -> chord
                | _  -> chord.[0..(i-1)]

let Deslash chords =
    chords
    |> Seq.map DeslashChord
    |> Seq.distinct
