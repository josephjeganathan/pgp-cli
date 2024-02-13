module Encryption

open System.IO
open PgpCore

type EncryptOptions = { PublicKeyPath: string }

type DecryptOptions =
    { PrivateKeyPath: string
      PassPhrase: string }

type GenKeyOptions =
    { OutputDir: string
      Email: string
      PassPhrase: string }

let private encryptOrDecryptFile op inputFilePath outputFilePath =
    inputFilePath
    |> File.ReadAllText
    |> op
    |> fun content -> File.WriteAllText(outputFilePath, content)

let encrypt options unencryptedContent =
    options.PublicKeyPath
    |> File.ReadAllText
    |> EncryptionKeys
    |> fun key -> new PGP(key)
    |> fun pgp -> pgp.Encrypt unencryptedContent

let decrypt options encryptedContent =
    options.PrivateKeyPath
    |> File.ReadAllText
    |> fun key -> EncryptionKeys(key, options.PassPhrase)
    |> fun key -> new PGP(key)
    |> fun pgp -> pgp.Decrypt encryptedContent

let encryptFile options = encryptOrDecryptFile (encrypt options)
let decryptFile options = encryptOrDecryptFile (decrypt options)

let genKeys options =
    use pgp = new PGP()

    pgp.GenerateKey(
        FileInfo($"{options.OutputDir}/public.asc"),
        FileInfo($"{options.OutputDir}/private.asc"),
        options.Email,
        options.PassPhrase
    )