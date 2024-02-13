namespace PgpCli

open System.ComponentModel
open Spectre.Console
open Spectre.Console.Cli
open Encryption

type EncryptCommandSettings() =
    inherit CommandSettings()

    [<Description("File to encrypt")>]
    [<CommandArgument(0, "<FILE-TO-ENCRYPT>")>]
    member val FileToEncrypt : string = null with get, set

    [<Description("Output file path")>]
    [<CommandOption("-o|--output-file")>]
    [<DefaultValue("./encrypted.pgp")>]
    member val OutputFile : string = null with get, set

    [<Description("Public key path (PGP)")>]
    [<CommandOption("-k|--key")>]
    [<DefaultValue("./public.asc")>]
    member val PublicKeyPath : string = null with get, set

type EncryptCommand() =
    inherit Command<EncryptCommandSettings>()

    override this.Execute (_, settings) =
        
        let print = AnsiConsole.MarkupLine
        let options =
            { PublicKeyPath = settings.PublicKeyPath }

        encryptFile options settings.FileToEncrypt settings.OutputFile

        print $"Encrypted [green]{settings.FileToEncrypt}[/] into [blue]{settings.OutputFile}[/]"
        
        0
