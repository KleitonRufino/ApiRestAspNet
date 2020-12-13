FROM mysql:5.7.22
EXPOSE 3306
COPY ./ApiRestASPNET/db/migrations/ /home/database/
COPY ./ApiRestASPNET/db/dataset/ /home/database/
COPY ./ApiRestASPNET/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh