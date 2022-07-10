#!/bin/zsh
cd $(dirname $0)

dotnet Luban.ClientServer/Luban.ClientServer.dll -j cfg -- \
    -d Defines/__root__.xml \
    --input_data_dir Excels \
    --output_code_dir ../HEDAO/Assets/GameMain/Scripts/Cfg/Gen \
    --output_data_dir ../HEDAO/Assets/GameMain/Res/Cfg/Bytes \
    --gen_types code_cs_unity_bin,data_bin \
    -s all \