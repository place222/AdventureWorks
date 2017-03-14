
FROM microsoft/aspnetcore:1.1
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
#打印一下copy进去的文件
RUN dir WORKDIR
ENTRYPOINT ["dotnet", "Webapi.dll"]
