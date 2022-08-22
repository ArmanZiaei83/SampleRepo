FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY *.csproj .
RUN dotnet restore
COPY . . 
ENV CONNECTION_STRING="Server=mssql,1401; Database=Test;User Id=sa; Password=Arman123!;"
RUN dotnet publish -c Release -o output

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app
COPY --from=build /src/output .
EXPOSE 88
ENTRYPOINT ["dotnet", "Sample.Migrations.dll"]