// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.




open AzureTableClient.AzureTable


[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    
    let addDataFn = init () 
    addDataFn "myTest7" |> ignore
    
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
