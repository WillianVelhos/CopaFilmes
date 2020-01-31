FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CopaFilmes.Test/CopaFilmes.Test.csproj", "CopaFilmes.Test/"]
COPY ["CopaFilmes.Domain/CopaFilmes.Domain.csproj", "CopaFilmes.Domain/"]
RUN dotnet restore "CopaFilmes.Test/CopaFilmes.Test.csproj"
COPY . .
WORKDIR "/src/CopaFilmes.Test"

RUN dotnet test "CopaFilmes.Test.csproj" 

