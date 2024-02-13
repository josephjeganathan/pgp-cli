namespace PgpCli

open System.ComponentModel
open Spectre.Console
open Spectre.Console.Cli
open Encryption

type DecryptCommandSettings() =
    inherit CommandSettings()

    [<Description("File to decrypt")>]
    [<CommandArgument(0, "<FILE-TO-DECRYPT>")>]
    member val FileToEncrypt: string = null with get, set

    [<Description("Passphrase for private key")>]
    [<CommandArgument(1, "<PASSPHRASE>")>]
    member val PassPhrase: string = null with get, set

    [<Description("Output file path")>]
    [<CommandOption("-o|--output-file")>]
    [<DefaultValue("./decrypted.pgp")>]
    member val OutputFile: string = null with get, set

    [<Description("Private key path (PGP)")>]
    [<CommandOption("-k|--key")>]
    [<DefaultValue("./private.asc")>]
    member val PrivateKeyPath: string = null with get, set

type DecryptCommand() =
    inherit Command<DecryptCommandSettings>()

    override this.Execute(_, settings) =

        let print = AnsiConsole.MarkupLine
        let options =
            { PrivateKeyPath = settings.PrivateKeyPath
              PassPhrase = settings.PassPhrase }

        decryptFile options settings.FileToEncrypt settings.OutputFile

        print $"Decrypted [green]{settings.FileToEncrypt}[/] into [blue]{settings.OutputFile}[/]"

        0
