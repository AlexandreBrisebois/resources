sudo docker-compose -p megaphone-app -f docker-compose-app.yml down

sudo docker-compose -p megaphone-infra -f docker-compose-infra.yml down

sudo docker volume prune -f