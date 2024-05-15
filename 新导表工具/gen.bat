set LUBAN_DLL=Luban\Luban.dll
set CONF_ROOT=DataTables

dotnet %LUBAN_DLL% ^
    -t client ^
    -c cs-bin ^
    -d bin  ^
    --conf %CONF_ROOT%\luban.conf ^
    -x outputCodeDir=..\HEDAO\Assets\GameMain\Scripts\Cfg\Gen ^
    -x outputDataDir=..\HEDAO\Assets\GameMain\Res\Cfg\Bytes

pause