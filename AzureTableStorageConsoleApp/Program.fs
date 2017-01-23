// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.




open AzureTableClient.AzureTable


[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    
    let x = init
    
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
