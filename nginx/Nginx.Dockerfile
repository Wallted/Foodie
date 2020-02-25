FROM nginx:latest

COPY nginx.conf /etc/nginx/nginx.conf
COPY 46.101.125.72.crt /etc/ssl/certs/46.101.125.72.crt
COPY 46.101.125.72.key /etc/ssl/private/46.101.125.72.key
#RUN certutil -d sql:$HOME/.pki/nssdb -A -t "P,," -n "46.101.125.72" -i /etc/ssl/certs/46.101.125.72.crt
