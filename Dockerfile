# Use official .NET SDK to build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY . .

# Restore dependencies and publish
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Use .NET runtime for final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose port 8080 for Render
EXPOSE 8080

# Set environment variables
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Run the app
ENTRYPOINT ["dotnet", "Monii.com.dll"]
