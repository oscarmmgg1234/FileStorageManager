#!/bin/bash
#have docker installed in system
#install ready-to-go mysql container
chmod +x setup-db.sh

docker exec fsdb /bin/bash -c "mysql -u root -pmy-secret-pw;" 


