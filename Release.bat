@echo off

echo ==========================================
echo Limpando Release
echo ==========================================

if exist Release rmdir /S /Q Release

mkdir Release

echo.
echo ==========================================
echo Publicando CaptureHub
echo ==========================================

dotnet publish CaptureHub\CaptureHub.csproj ^
-c Release ^
-r win-x64 ^
-p:Platform=x64 ^
-p:PublishSingleFile=false ^
-p:PublishTrimmed=false ^
-p:DebugType=None ^
--self-contained true ^
-o Release

if errorlevel 1 goto erro

echo.
echo ==========================================
echo Publicando VideoTranscript
echo ==========================================

dotnet publish VideoTranscript\VideoTranscript.csproj ^
-c Release ^
-r win-x64 ^
-p:Platform=x64 ^
-p:PublishSingleFile=false ^
-p:PublishTrimmed=false ^
-p:DebugType=None ^
--self-contained true ^
-o Release

if errorlevel 1 goto erro

echo.
echo ==========================================
echo BUILD CONCLUIDO
echo ==========================================
pause
exit /b 0

:erro
echo.
echo ==========================================
echo ERRO NO BUILD
echo ==========================================
pause
exit /b 1