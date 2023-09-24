#!/bin/bash

# Grant execution permissions for this script with the following command:
# chmod +x docker.sh

# Reference: https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-bash

# Pull the latest SQL Server 2019 container image from Microsoft Container Registry
# sudo docker pull mcr.microsoft.com/mssql/server:2022-latest

# Pull and Run the SQL Server container
# sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourStrong@Passw0rd" -p 1433:1433 --name sql1 --hostname sql1 -d mcr.microsoft.com/mssql/server:2022-latest

# Run the SQL Server container
sudo docker start sql1

# Connect to the SQL Server container
# sudo docker exec -it sql1 "bash"

# Create a database
# CREATE DATABASE GardenTracker;
# GO
# SELECT Name from sys.databases;
# GO

# Stop the container
# sudo docker stop sql1