# theuc Ingress Controller

theuc Ingress Controller Project based on YARP.  

More info: <https://github.com/microsoft/reverse-proxy>

## Build & Deploy

```shell
docker build -f src/theuc.IngressController/Dockerfile -t theabc:latest .

helm upgrade theabc ./helm-chart --install -f values.yaml
```
