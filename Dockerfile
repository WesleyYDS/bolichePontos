FROM mcr.microsoft.com/dotnet/core/sdk AS build-env

RUN mkdir -p /usr/share/man/man1 /usr/share/man/man2

RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jre

RUN dotnet tool install --global dotnet-sonarscanner --version 4.10.0
ENV PATH="${PATH}:/root/.dotnet/tools"
ENV JAVA_TOOL_OPTIONS -Dfile.encoding=UTF8

COPY . ./bolichePontos
WORKDIR /bolichePontos

RUN dotnet restore

RUN dotnet test \
    /p:CollectCoverage=true \
    /p:CoverletOutputFormat=opencover

RUN dotnet sonarscanner begin /k:"wes_bolichePontos" \
    /d:sonar.host.url="http://192.168.0.101:9000" \
    /d:sonar.verbose=true \
    /v:1.0.0 \
    /d:sonar.login="8a294d58dc17872816d5d9330e426730a2f23bdb" \
    /d:sonar.cs.opencover.reportsPaths="./bolicheTests/coverage.opencover.xml"

RUN dotnet build
RUN dotnet sonarscanner end /d:sonar.login="8a294d58dc17872816d5d9330e426730a2f23bdb"