#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim
WORKDIR /app
EXPOSE 80
EXPOSE 443


WORKDIR /app
COPY .  /app
ENTRYPOINT ["dotnet", "Rbac.WebAPI.dll"]