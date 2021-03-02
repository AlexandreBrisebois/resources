#!/bin/bash

echo "deploy infra"
sudo docker-compose -p megaphone-infra -f docker-compose-infra.yml up -d

echo "wait (1 minute) for SQL to be ready"
sleep 1m

echo "create megaphone database"
sudo docker exec -it sqlserver /opt/mssql-tools/bin/sqlcmd \
   -S localhost -U sa -P "Qwerty1!" \
   -Q 'CREATE DATABASE megaphone'

echo "deploy app"
sudo docker-compose -p megaphone-app -f docker-compose-app.yml up -d