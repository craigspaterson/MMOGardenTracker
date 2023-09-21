#!/bin/bash

# Grant execution permissions for this script with the following command:
# chmod +x docker.sh

# docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<your value>" -p 1433:1433 --name sql2022 --hostname sql2022 -d mcr.microsoft.com/mssql/server:2022-latest –platform linux/amd64
sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourStrong@Passw0rd" -p 1433:1433 --name sql1 --hostname sql1 -d mcr.microsoft.com/mssql/server:2022-latest

sudo docker exec -it sql1 "bash"

# CREATE DATABASE GardenTracker;
# GO
# SELECT Name from sys.databases;
# GO
