module Deflavourer

open System.Collections.Generic
open Result

let flavours = dict[ 
                     "", ""; 
                     "maj", ""; 
                     "6", ""; 
                     "7", ""; 
                     "add9", ""; 
                     "2", ""; 
                     "maj7", "";
                     "M", "";
                     "7b9", "";
                     "9", "";
                     "maj9", "";
                     "7#9", "";
                     "11", "";
                     
                     "m", "m"; 
                     "min", "m";
                     "m6", "m"; 
                     "m7", "m"; 
                     "mM7", "m"; 
                     "m9", "m"; 
                     "m11", "m"; 

                     "aug", "aug"; 
                     "7#5", "aug"; 
                     "9#5", "aug"; 

                     "dim", "dim"; 
                     "dim7", "dim"; 
                     "m7b5", "dim";
                                    ]

let DeflavourChord chord =
    chord
    |> Analyzer.AnalyzeChord 
    |> fun (tonic, flavour) -> tonic + flavours.Item flavour

let Deflavour chords =
    try
        chords
        |> Seq.map DeflavourChord
        |> Seq.toList // force evaluation
        |> Seq.distinct
        |> Success
    with
        | :? KeyNotFoundException -> Failure UnknownFlavour
