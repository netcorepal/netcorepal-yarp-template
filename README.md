# netcorepal-yarp-template

## How to Build

```shell
dotnet pack -o ./
dotnet new uninstall NetCorePal.YARP.Template
dotnet new install NetCorePal.YARP.Template.1.0.0.nupkg
```

## How to use

```shell
dotnet new install NetCorePal.YARP.Template
dotnet new update NetCorePal.YARP.Template
dotnet new yarpingresscontroller -n yourname
```

## test

```shell
kubectl apply -f test.yaml  
```
