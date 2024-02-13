# PGP CLI

PGP CLI uses PGPCore to,

- Generate public/private keys
- Encrypt files
- Decrypt files

## Install as dotnet tool

Checkout code and run the following commands

```sh
dotnet pack
dotnet tool install --global --add-source ./pgp-cli/nupkg pgp-cli
```

### Using PGP CLI

#### Get Help

```
pgp --help
```

#### Generate keys

```
pgp gen-key "test@test.com" "my-strong-password"
```

#### Encrypt File

```
pgp encrypt myfile.txt -k ./public.asc -o ./encrypted.pgp
```

#### Decrypt File

```
pgp decrypt ./encrypted.pgp "mypassword" -k ./private.asc -o ./decrypted.pgp
```

## Uninstall dotnet tool

```sh
dotnet tool uninstall -g pgp-cli
```
