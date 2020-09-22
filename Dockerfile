FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /src
COPY ./TracerBreaker.csproj .
COPY . .
RUN dotnet restore TracerBreaker.csproj
RUN dotnet build -c Release -o /app
FROM build AS publish
WORKDIR /src
RUN dotnet add TracerBreaker.csproj package Instana.Tracing.Core.Rewriter.Alpine --version 1.1.1
RUN dotnet add TracerBreaker.csproj package Instana.Tracing.Core --version 1.1.56
RUN dotnet publish -c Release -o out
ENV CORECLR_ENABLE_PROFILING=1
ENV CORECLR_PROFILER={cf0d821e-299b-5307-a3d8-b283c03916dd}
ENV CORECLR_PROFILER_PATH=/app/instana_tracing/CoreProfiler.so
ENV DOTNET_STARTUP_HOOKS=/app/Instana.Tracing.Core.dll
FROM base AS final
WORKDIR /app
COPY --from=publish /src/out .
ENTRYPOINT ["dotnet", "TracerBreaker.dll"]