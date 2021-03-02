#!/bin/bash

echo "deploy app only"
sudo docker-compose -p megaphone-app -f docker-compose-app.yml up -d --force-recreate