module internal Deslasher

let DeslashChord (chord: string) =
    chord.IndexOf('/')
    |> function
       | -1 -> chord
       | 0  -> invalidArg "chord" "chord must not start with slash"
       | i  -> chord.[0..(i-1)]

let Deslash chords =
    chords
    |> Seq.map DeslashChord
    |> Seq.distinct
