FROM microsoft/dotnet:2.2-sdk

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./customer-information-api.sln ./
COPY ./customer-information-api/customer-information-api.csproj ./customer-information-api/
COPY ./customer-information-api.Tests/customer-information-api.Tests.csproj ./customer-information-api.Tests/

RUN dotnet restore ./customer-information-api/customer-information-api.csproj
RUN dotnet restore ./customer-information-api.Tests/customer-information-api.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out customer-information-api.Tests/customer-information-api.Tests.csproj

CMD dotnet test
