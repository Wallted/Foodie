FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_18.x | bash \
    && apt-get install nodejs -yq

ARG APP_VERSION

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN echo "export const version = '${APP_VERSION}';" > ClientApp/src/environments/version.ts
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
COPY --from=build-env /app/out .
COPY example.pfx .
ENTRYPOINT ["dotnet", "Foodie.dll"]