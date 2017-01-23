namespace AzureTableClient

open Microsoft.Azure
open Microsoft.WindowsAzure.Storage
open Microsoft.WindowsAzure.Storage.Table

module AzureTable = 
    open System

    type LocationEntity(param1) =
        inherit TableEntity(DateTime.Today.ToString("yyyy-MM-dd"), (Guid.NewGuid ()).ToString ())
        member this.Param1:string = param1
            
    let init () = 

        let csa:CloudStorageAccount = CloudStorageAccount.Parse (CloudConfigurationManager.GetSetting "StorageConnectionString")
        let ctc = csa.CreateCloudTableClient ()
        let location = ctc.GetTableReference "location"

        let created:bool = location.CreateIfNotExists () 
                
        let insertLocationFn a = 
            let locationEntity = new LocationEntity(a)        
            let insertOperation:TableOperation = TableOperation.Insert(locationEntity)        
            let tableResult:TableResult = location.Execute(insertOperation) 
            
            tableResult
                           
        insertLocationFn


        //()
        //(fun () -> ())