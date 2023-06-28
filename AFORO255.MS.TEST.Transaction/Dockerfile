#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
#COPY ["AFORO255.MS.TEST.Transaction/AFORO255.MS.TEST.Transaction.csproj", "AFORO255.MS.TEST.Transaction/"]
#RUN dotnet restore "AFORO255.MS.TEST.Transaction/AFORO255.MS.TEST.Transaction.csproj"
#COPY . .
#WORKDIR "/src/AFORO255.MS.TEST.Transaction"
#RUN dotnet build "AFORO255.MS.TEST.Transaction.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "AFORO255.MS.TEST.Transaction.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "AFORO255.MS.TEST.Transaction.dll"]
#------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
#FROM mcr.microsoft.com/dotnet/aspnet:7.0
#WORKDIR /app
#
#COPY ./publish/ /app
#ENV ASPNETCORE_URLS=http://+:8080
#ENV ASPNETCORE_ENVIRONMENT docker
#EXPOSE 8080
#
#ENTRYPOINT ["dotnet", "/app/AFORO255.MS.TEST.Transaction.dll"]
#------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ARG PROJECT_NAME=AFORO255.MS.TEST.Transaction

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG PROJECT_NAME
ENV PROJECT=$PROJECT_NAME
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish ${PROJECT}.csproj -c release -o publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0
ARG PROJECT_NAME
ENV PROJECT=$PROJECT_NAME
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS http://*:8080
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 8080
ENTRYPOINT dotnet ${PROJECT}.dll