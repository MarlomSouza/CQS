#!/bin/bash

set -e

run_cmd="dotnet run -p ./src/UI/"

sleep 5

until dotnet ef database update --startup-project ./src/UI/ ; do
>&2 echo "######################SQL Server is starting up"
sleep 1
done

>&2 echo "##################SQL Server is up - executing command"
exec $run_cmd