open Spectre.Console.Cli
open PgpCli

[<EntryPoint>]
let main args =

    let app = CommandApp()
    app.Configure(fun config ->
        config.AddCommand<GenKeyCommandCommand>("gen-key") |> ignore
        config.AddCommand<EncryptCommand>("encrypt") |> ignore
        config.AddCommand<DecryptCommand>("decrypt") |> ignore
    )

    app.Run(args)