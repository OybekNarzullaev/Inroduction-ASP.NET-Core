# Use .NET 8 SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project files and restore dependencies
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o /out

# Use .NET 8 runtime image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

# Ensure the database directory exists
RUN mkdir -p /app/Data

# Copy the SQLite database from your project to the container
COPY --from=build /app/Data/OnlineMarket.db /app/Data/OnlineMarket.db

# Set the connection string to use this path
ENV ConnectionStrings__DefaultConnection="Data Source=/app/Data/OnlineMarket.db"

# Expose the port your app runs on (default: 80)
EXPOSE 80

# Start the app
ENTRYPOINT ["dotnet", "OnlineMarket.dll"]
