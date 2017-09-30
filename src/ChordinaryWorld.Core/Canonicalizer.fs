module internal Canonicalizer

open System.Text.RegularExpressions

let replace (x: string) (y: string) s = Regex.Replace(s, x, y)

let Preformat(s: string) =
    s
     .Trim()
     .ToLower()

let HandlePunctuation =
       replace "/"  " "
    >> replace "\?" ""

let HandleSpaces = replace "\s+" " "

let Canonicalize = 
    Preformat
    >> HandlePunctuation
    >> HandleSpaces