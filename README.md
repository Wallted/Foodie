# Foodie

Web application, which purpose is to help you maintain your diet by calculating caloric demand and managing meals so as not to exceed it. Visit [this site](https://www.walltedo.com) and try it yourself!

## Features
- calculate your caloric demand based on various personal traits
- track calories throughout each day divided into carbohydrates, fats and proteins presented as progress bars
- easily add new meals containing different ingriedients
- manage your favorite products, each with defined amount of macroelements

Incoming features:
- splitting meals

## Technology

Foodie is a Progressive Web Application (PWA) developed in **.NetCore 3.0** as backend and **Angular 7** as frontend. It uses **MSSQL Server** as DBMS and because PWA needs SSL to actually work, **Nginx** serves as reverse-proxy server using **Let's Encrypt** certificate. All of this contenerized in **Docker**.

<!---
## Proggresive Web Application (PWA)

## Docker

## Build

## Nginx -->

## Localhost SSL (Chrome)

In order to trust app locally, cert **nginx/localhost.crt** need to be trusted.

### Windows

Double click -> Install certificate and insert it in *Trusted Root Certification Authorities* storage.

### OSX
Hit one command:

`sudo security add-trusted-cert -d -r trustRoot -k /Library/Keychains/System.keychain nginx/localhost.crt`


#### Grzegorz Choiński 2020