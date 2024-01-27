#!/bin/bash

rm -rf .env
echo $TAG >> .env
echo $REGISTRY >> .env
echo $IMAGE_NAME >> .env
echo $CERT_KEY >> .env
echo $CERT_FULLCHAIN >> .env

rm -rf .nginx
mkdir .nginx
cd .nginx
echo $PRIVATE_KEY > privkey.pem
echo $CERTIFICATE > fullchain.pem
echo $NGINX_CONF > nginx.conf
