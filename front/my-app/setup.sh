#!/bin/bash
if  [ "$1" == "none" ]; 
then
 echo "no Domain"
else
 certbot --nginc -d "$1" -d wwww."$1"
fi
nginx -g daemon off;