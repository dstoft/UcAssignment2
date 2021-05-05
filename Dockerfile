# ---- dotnet build stage ----
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build

ARG BUILDCONFIG=RELEASE
ARG VERSION=1.0.0

WORKDIR /build/

COPY ./UcAssignment2/UcAssignment2.csproj ./UcAssignment2.csproj
RUN dotnet restore ./UcAssignment2.csproj

COPY ./UcAssignment2 ./

RUN dotnet build -c ${BUILDCONFIG} -o out && dotnet publish ./UcAssignment2.csproj -c ${BUILDCONFIG} -o out /p:Version=${VERSION}

# ---- final stage ----
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

ENV DOTNET_PROGRAM_HOME=/opt/UcAssignment2

COPY --from=build /build/out ${DOTNET_PROGRAM_HOME}

ENTRYPOINT ["dotnet", "/opt/UcAssignment2/UcAssignment2.dll"]