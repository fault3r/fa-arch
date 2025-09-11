#!/bin/bash

solutions=(
  "GrpcService/GrpcService.sln"
  "GrapqlService/GraphqlService.sln"
  "ItemService/ItemService.sln"
  "JwtService/JwtService.sln"
)

for sln in "${solutions[@]}"; do
  if [ -f "$sln" ]; then
    echo "Cleaning $sln ..."
    dotnet clean "$sln"
  else
    echo "Solution file $sln not found!"
  fi
done
