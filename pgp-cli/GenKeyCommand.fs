namespace PgpCli

open System.ComponentModel
open Spectre.Console
open Spectre.Console.Cli
open Encryption

type GenKeyCommandSettings() =
    inherit CommandSettings()

    [<Description("Email")>]
    [<CommandArgument(0, "<EMAIL>")>]
    member val Email: string = null with get, set

    [<Description("Passphrase for private key")>]
    [<CommandArgument(1, "<PASSPHRASE>")>]
    member val PassPhrase: string = null with get, set

    [<Description("Output directory path")>]
    [<CommandOption("-o|--output-directory")>]
    [<DefaultValue("./")>]
    member val OutputDir: string = null with get, set

type GenKeyCommandCommand() =
    inherit Command<GenKeyCommandSettings>()

    override this.Execute(_, settings) =

        let print = AnsiConsole.MarkupLine
        let options =
            { OutputDir = settings.OutputDir
              Email = settings.Email
              PassPhrase = settings.PassPhrase }

        genKeys options

        print $"Generated keys in [green]{settings.OutputDir}[/]"

        0
