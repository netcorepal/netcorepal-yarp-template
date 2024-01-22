# netcorepal-yarp-template

[![Release Build](https://img.shields.io/github/actions/workflow/status/netcorepal/netcorepal-yarp-template/release.yml?label=release%20build)](https://github.com/netcorepal/netcorepal-yarp-template/actions/workflows/release.yml)
[![Preview Build](https://img.shields.io/github/actions/workflow/status/netcorepal/netcorepal-yarp-template/dotnet.yml?label=preview%20build)](https://github.com/netcorepal/netcorepal-yarp-template/actions/workflows/dotnet.yml)
[![NuGet](https://img.shields.io/nuget/v/NetCorePal.YARP.Template.svg)](https://www.nuget.org/packages/NetCorePal.YARP.Template)
[![MyGet Preview](https://img.shields.io/myget/netcorepal/vpre/NetCorePal.YARP.Template?label=preview)](https://www.myget.org/feed/netcorepal/package/nuget/NetCorePal.YARP.Template)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/netcorepal/netcorepal-yarp-template/blob/main/LICENSE)

## How to Build

```shell
dotnet pack -o ./
dotnet new uninstall NetCorePal.YARP.Template
dotnet new install NetCorePal.YARP.Template.1.0.0.nupkg
```

## How to use

```shell
dotnet new install NetCorePal.YARP.Template
dotnet new yarpingresscontroller -n yourname
```

## test

```shell
kubectl apply -f test.yaml  
```
