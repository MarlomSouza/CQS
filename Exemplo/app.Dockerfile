# FROM microsoft/dotnet:sdk AS build-env
# WORKDIR /app

# # Copy csproj and restore as distinct layers
# COPY *.csproj ./
# ARG Ambiente
# COPY appsettings.${Ambiente}${Ambiente:+.}json ./
# RUN dotnet restore

# COPY . ./

# RUN dotnet publish -c Release -o out

# # Build runtime image
# FROM microsoft/dotnet:aspnetcore-runtime
# WORKDIR /app
# COPY --from=build-env /app/out .
# EXPOSE 80
# ENTRYPOINT ["dotnet", "exemplo.dll"]
FROM microsoft/dotnet:sdk 
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 80/tcp
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh