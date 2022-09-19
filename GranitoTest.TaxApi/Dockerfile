#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 444

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GranitoTest.TaxApi/GranitoTest.TaxApi.csproj", "GranitoTest.TaxApi/"]
RUN dotnet restore "GranitoTest.TaxApi/GranitoTest.TaxApi.csproj"
COPY . .
WORKDIR "/src/GranitoTest.TaxApi"
RUN dotnet build "GranitoTest.TaxApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GranitoTest.TaxApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GranitoTest.TaxApi.dll"]