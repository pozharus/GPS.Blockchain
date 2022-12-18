FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

WORKDIR /app
COPY GPS.Blockchain.sln ./

COPY Core/Blockchain.Domain/Blockchain.Domain.csproj ./Core/Blockchain.Domain/
COPY Core/Blockchain.Application/Blockchain.Application.csproj ./Core/Blockchain.Application/
COPY Infrastructure/Blockchain.Persistance/Blockchain.Persistance.csproj ./Infrastructure/Blockchain.Persistance/
COPY Presentation/Blockchain.WebApi/Blockchain.WebApi.csproj ./Presentation/Blockchain.WebApi/
RUN dotnet restore

COPY . .
WORKDIR /app/Core/Blockchain.Domain/
RUN dotnet build -c Release -o /app/out
WORKDIR /app/Core/Blockchain.Application/
RUN dotnet build -c Release -o /app/out
WORKDIR /app/Infrastructure/Blockchain.Persistance/
RUN dotnet build -c Release -o /app/out
WORKDIR /app/Presentation/Blockchain.WebApi/
RUN dotnet build -c Release -o /app/out

WORKDIR /app
RUN dotnet publish -c Release -o /app/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Blockchain.WebApi.dll"]