@echo off
title "eda12131190311906 Documentation compiler"

echo #
echo # Estruturas de Dados e Algoritmos (EDA) - Project I
echo # Tiago Conceição Nº 11903
echo # Gonçalo Lampreia Nº 11906
echo # https://code.google.com/p/eda12131190311906/
echo #
echo # Build and compile project
echo #

ping 1.1.1.1 -n 1 -w 3000 > nul
doxygen
cd latex
make.bat
ping 1.1.1.1 -n 1 -w 3000 > nul

pause