module internal Canonicalizer

open System.Globalization
open System.Text.RegularExpressions

let replace (x: string) (y: string) s = Regex.Replace(s, x, y)

let trim (s: string) = s.Trim()

let titlize = CultureInfo("en-US", false).TextInfo.ToTitleCase

let Preformat = trim >> titlize

let HandlePunctuation =
       replace "/"  " "
    >> replace "\?" ""

let HandleSpaces = replace "\s+" " "

let Canonicalize = 
    Preformat
    >> HandlePunctuation
    >> HandleSpaces