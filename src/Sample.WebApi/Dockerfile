ARG PORT=80
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
ENV CONNECTION_STRING="Server=172.26.0.1,5435; Database=Test;User Id=sa; Password=Arman123!;"
ENV ASPNETCORE_ENVIRONMENT=Development

COPY ../Sample.WebApi/Sample.WebApi.csproj "Sample.WebApi/"
COPY ../Infrastructure.Persistence/Infrastructure.Persistence.csproj "Sample.Infrastructure.Persistence/"
COPY ../Sample.Application/Sample.Application.csproj "Sample.Application/"

RUN dotnet restore "Sample.WebApi/Sample.WebApi.csproj"
COPY . .
WORKDIR "/src/Sample.WebApi"
RUN dotnet build "Sample.WebApi.csproj" -c Release -o /app/build
RUN dotnet publish "Sample.WebApi.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE $PORT
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Sample.WebApi.dll"]