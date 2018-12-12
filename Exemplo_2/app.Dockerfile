
FROM microsoft/dotnet:2.2-sdk 
WORKDIR /app
COPY ["./", "./" ]
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
RUN chmod +x ./src/Infra/entrypoint.sh
EXPOSE 5000 5001
CMD /bin/bash ./src/Infra/entrypoint.sh