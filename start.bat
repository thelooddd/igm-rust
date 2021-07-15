@echo off
cls
:start
echo Starting server...

RustDedicated.exe -batchmode -nographics +server.hostname "IGM Server" +server.maxplayers 120 +server.headerimage "http://i.imgur.com/xNyLhMt.jpg" +server.url "igmvk.ru" +rcon.ip 127.0.0.1 +rcon.port 28016 +rcon.password "DSAnjd127dsand712nd7sadn1" +server.ip 127.0.0.1 +server.port 28015 +server.tickrate 30 +server.identity "server" +server.worldsize 4000 +server.saveinterval 600 +server.seed 12345 +server.level "Procedural Map" -logFile "output.txt" +server.description "IGM Server" -autoupdate

echo.
echo Restarting server...
timeout /t 10
echo.
goto start
