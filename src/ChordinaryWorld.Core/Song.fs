[<AutoOpen>]
module internal Song

[<Struct>]
type Song = { Artist: string; Title: string } with
    
    static member Create (artist, title) = 
        { Artist = artist; Title = title } 
