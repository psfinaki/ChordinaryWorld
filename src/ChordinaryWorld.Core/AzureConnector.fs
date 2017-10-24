module internal AzureConnector

open System
open FSharp.Configuration
open Microsoft.Azure.Documents.Client
open Microsoft.Azure.Documents

type Config = YamlConfig<"config.yaml">

type DocumentClient with 
    member private this.GetCollectionsLinkByDatabase database =
        this
            .CreateDatabaseIfNotExistsAsync(database)
            .Result
            .Resource
            .CollectionsLink

    member private this.GetDocumentsLinkByCollection (link: string) collection =
        this
            .CreateDocumentCollectionIfNotExistsAsync(link, collection)
            .Result
            .Resource
            .DocumentsLink

    member this.GetDocumentsLink databaseId collectionId =
        let database = Database()
        database.Id <- databaseId
        let collectionsLink = this.GetCollectionsLinkByDatabase database

        let collection = DocumentCollection()
        collection.Id <- collectionId
        let documentsLink = this.GetDocumentsLinkByCollection collectionsLink collection

        documentsLink

let SaveDocument document = 
    let config = Config()
    
    use client = new DocumentClient(config.Uri, config.Key) 
    let documentsLink = client.GetDocumentsLink config.DatabaseId config.CollectionId
    
    client.UpsertDocumentAsync(documentsLink, document).Result |> ignore

let GetTop count =
    try
        let config = Config()
        use client = new DocumentClient(config.Uri, config.Key) 
    
        client.GetDocumentsLink config.DatabaseId config.CollectionId
        |> client.CreateDocumentQuery<Song>
        |> Seq.sortByDescending (fun s -> s.harmonies)
        |> Seq.take count
        |> Seq.map (fun s -> s.artist, s.title, s.harmonies)
        |> Seq.toList
        |> succeed
    with
        | :? ArgumentException         -> Failure NegativeCount
        | :? InvalidOperationException -> Failure TooBigCount