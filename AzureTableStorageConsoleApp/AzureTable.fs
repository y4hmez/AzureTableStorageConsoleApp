namespace AzureTableClient

open Microsoft.Azure
open Microsoft.WindowsAzure.Storage
open Microsoft.WindowsAzure.Storage.Table

module AzureTable = 
    open System

    type LocationEntity(param1) =
        inherit TableEntity(DateTime.Today.ToString("yyyy-MM-dd"), (Guid.NewGuid ()).ToString ())
        member this.Param1 = param1
        
    let init:CloudTable = 

        let csa:CloudStorageAccount = CloudStorageAccount.Parse (CloudConfigurationManager.GetSetting "StorageConnectionString")
        let ctc = csa.CreateCloudTableClient ()
        let location = ctc.GetTableReference "location"

        //location.Delete () |> ignore
        
        let created:bool = location.CreateIfNotExists () 
        
        let loc1 = new LocationEntity("some param")
        
        let insertOperation:TableOperation = TableOperation.Insert(loc1)        
        let tableResult:TableResult = location.Execute(insertOperation) 
        
       
        location
        //()
        //(fun () -> ())