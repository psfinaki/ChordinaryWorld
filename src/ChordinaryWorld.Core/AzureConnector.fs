module AzureConnector

open System
open Microsoft.Azure.Documents.Client
open Microsoft.Azure.Documents

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
    let uri = "https://chordinaryworld.documents.azure.com:443/"
    let key = "secret"
    use client = new DocumentClient(Uri uri, key) 
    
    let database = Database()
    database.Id <- "Music"
    let collectionsLink = client.GetCollectionsLink database

    let collection = DocumentCollection()
    collection.Id <- "Songs"
    let documentsLink = client.GetDocumentsLink collectionsLink collection

    client.CreateDocumentAsync(documentsLink, document).Result |> ignore