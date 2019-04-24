FROM microsoft/dotnet:2.2-sdk
WORKDIR /app

COPY CaixeiroViajante/*.csproj ./
RUN dotnet restore

COPY CaixeiroViajante/. ./

RUN ls
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/CaixeiroViajante.dll"]