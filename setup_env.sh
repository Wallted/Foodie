#!/bin/bash

rm -rf .env
echo TAG=$TAG >> .env
echo IMAGE_NAME=$IMAGE_NAME >> .env
echo DOCKER_REGISTRY=$DOCKER_REGISTRY >> .env
echo CERT_PATH=$CERT_PATH >> .env
echo CERT_KEY_PATH=$CERT_KEY_PATH >> .env

rm -rf .nginx
mkdir .nginx
cd .nginx
echo "$PRIVATE_KEY" > privkey.pem
echo "$CERTIFICATE" > fullchain.pem
echo "$NGINX_CONF" > nginx.conf
