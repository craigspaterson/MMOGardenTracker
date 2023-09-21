#!/bin/bash

# Grant execution permissions for this script with the following command:
# chmod +x docker.sh

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<your value>" -p 1433:1433 --name sql2022 --hostname sql2022 -d mcr.microsoft.com/mssql/server:2022-latest –platform linux/amd64