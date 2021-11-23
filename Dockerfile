FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ./ ./
RUN dotnet restore \
    && dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
COPY --from=build /app/publish ./
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "Rytme.Recommendation.WebApi.dll"]