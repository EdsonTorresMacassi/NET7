#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
#COPY ["AFORO255.MS.TEST.Pay/AFORO255.MS.TEST.Pay.csproj", "AFORO255.MS.TEST.Pay/"]
#RUN dotnet restore "AFORO255.MS.TEST.Pay/AFORO255.MS.TEST.Pay.csproj"
#COPY . .
#WORKDIR "/src/AFORO255.MS.TEST.Pay"
#RUN dotnet build "AFORO255.MS.TEST.Pay.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "AFORO255.MS.TEST.Pay.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "AFORO255.MS.TEST.Pay.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

COPY ./publish/ /app
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/AFORO255.MS.TEST.Pay.dll"]