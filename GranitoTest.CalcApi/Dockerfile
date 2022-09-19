#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GranitoTest.CalcApi/GranitoTest.CalcApi.csproj", "GranitoTest.CalcApi/"]
COPY ["GranitoTest.Application/GranitoTest.Application.csproj", "GranitoTest.Application/"]
RUN dotnet restore "GranitoTest.CalcApi/GranitoTest.CalcApi.csproj"
COPY . .
WORKDIR "/src/GranitoTest.CalcApi"
RUN dotnet build "GranitoTest.CalcApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GranitoTest.CalcApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GranitoTest.CalcApi.dll"]