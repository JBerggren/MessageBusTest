FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MessageBusTest.csproj", "MessageBusTest/"]
RUN dotnet restore "MessageBusTest/MessageBusTest.csproj"

COPY . MessageBusTest/.
RUN dotnet publish -c Release -o /app MessageBusTest/MessageBusTest.csproj 

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS publish
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "MessageBusTest.dll"]