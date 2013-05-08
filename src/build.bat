@echo off
title "eda12131190311906 compiler"
set PROJECTFILE=eda12131190311906.sln
set CONFIGURATION=Release
set PROPERTIES = /property:Configuration=%CONFIGURATION%

echo #
echo # Estruturas de Dados e Algoritmos (EDA) - Project I
echo # Tiago Conceição Nº 11903
echo # Gonçalo Lampreia Nº 11906
echo # https://code.google.com/p/eda12131190311906/
echo #
echo # Build and compile project
echo #


if defined VS110COMNTOOLS (
   call "%VS110COMNTOOLS%\vsvars32.bat"
   goto compile
) else ( 
    if defined VS100COMNTOOLS (
         call "%VS110COMNTOOLS%\vsvars32.bat"
		 goto compile
    ) else ( 
        if defined VS90COMNTOOLS (
            call "%VS90COMNTOOLS%\vsvars32.bat"
			goto compile
        ) else ( 
            echo ERROR: msbuild require a valid instalation of Visual Studio 9, 10 or 11
			pause
        )
    )
)


:compile 
msbuild %PROPERTIES% %PROJECTFILE%
pause

:end