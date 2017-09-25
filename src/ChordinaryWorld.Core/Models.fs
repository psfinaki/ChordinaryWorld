[<AutoOpen>]
// do not make models internal, because that way
// id is not serialized correctly to Cosmos DB
module Models

type Song = 
    val id: string; 
    val artist : string; 
    val title : string; 
    val harmonies: int;

    new (artist, title, harmonies) = { 
        id = artist + " - " + title;
        artist = artist; 
        title = title; 
        harmonies = harmonies 
    }