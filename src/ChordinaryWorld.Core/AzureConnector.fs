module internal AzureConnector

open System
open FSharp.Configuration
open Microsoft.Azure.Documents.Client
open Microsoft.Azure.Documents

type Config = YamlConfig<"config.yaml">

type DocumentClient with 
    member this.GetCollectionsLink database =
        this
            .CreateDatabaseIfNotExistsAsync(database)
            .Result
            .Resource
            .CollectionsLink

    member this.GetDocumentsLink (link: string) collection =
        this
            .CreateDocumentCollectionIfNotExistsAsync(link, collection)
            .Result
            .Resource
            .DocumentsLink

let SaveDocument document = 
    let config = Config()
    use client = new DocumentClient(config.Uri, config.Key) 
    
    let database = Database()
    database.Id <- config.DatabaseId
    let collectionsLink = client.GetCollectionsLink database

    let collection = DocumentCollection()
    collection.Id <- config.CollectionId
    let documentsLink = client.GetDocumentsLink collectionsLink collection

    client.UpsertDocumentAsync(documentsLink, document).Result |> ignore

let GetTop count =
    try
        let config = Config()
        use client = new DocumentClient(config.Uri, config.Key) 
    
        let database = Database()
        database.Id <- config.DatabaseId
        let collectionsLink = client.GetCollectionsLink database

        let collection = DocumentCollection()
        collection.Id <- config.CollectionId
        let documentsLink = client.GetDocumentsLink collectionsLink collection
        
        documentsLink
        |> client.CreateDocumentQuery<Song>
        |> Seq.sortByDescending (fun s -> s.harmonies)
        |> Seq.take count
        |> Seq.map (fun s -> s.artist, s.title, s.harmonies)
        |> Seq.toList
        |> succeed
    with
        | :? ArgumentException         -> Failure NegativeCount
        | :? InvalidOperationException -> Failure TooBigCount