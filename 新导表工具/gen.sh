#!/bin/zsh
cd $(dirname $0)

dotnet Luban/Luban.dll \
    -t client \
    -c cs-bin \
    -d bin  \
    --conf DataTables/luban.conf \
    -x outputCodeDir=../HEDAO/Assets/Scripts/Cfg/Gen \
    -x outputDataDir=../HEDAO/Assets/Res/Cfg/Bytes \
