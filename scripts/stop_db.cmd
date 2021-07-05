@echo off
docker-compose -f "..\jobs_docker\docker-compose.yml" -f "..\jobs_docker\docker-compose.override.yml" stop