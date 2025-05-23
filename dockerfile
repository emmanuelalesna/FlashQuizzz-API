# In Dockerfile, we provide instructions on how to build a self-contained file system for my aplication and how to run my application
# If I want to run this app in Any machine what so ever,
# I need a runtime. ASP.NET Core 8 Runtime
# I also need published artifacts

# Start with .NET SDK 8 image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set my work dir to /app so everything happens here within the image
# Will make /app if it does not exist
WORKDIR /app

# Copy over the API project
COPY FlashQuizzz.API /app/FlashQuizzz.API

# Run dotnet publish and make artifact
RUN dotnet publish FlashQuizzz.API -c Release -o dist

# Start a new layer from the .NET 8 runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS run

# Tells aspnet to serve app over port 80
ENV ASPNETCORE_URLS=http://*:80

# Set work dir to /app again
WORKDIR /app

# Copy over the application artifact from /app/dist
COPY --from=build /app/dist .

# When "docker run" is called, execute "dotnet DarkkestP3.API.dll"
CMD [ "dotnet", "FlashQuizzz.API.dll"]

# run to build the image
# docker build -t username/name:0.0.1 .

# run to start the image in a container
# -d start in detached mode, frees up the terminal after
# -p to map host ports to container ports
# docker run -d -p 12123:80 username/name:0.0.1