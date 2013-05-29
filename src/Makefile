#
# Estruturas de Dados e Algoritmos (EDA) - Project I
# Tiago Conceição Nº 11903
# Gonçalo Lampreia Nº 11906
# https://code.google.com/p/eda12131190311906/
#
# Makefile - build and compile project
#

# Project file
PROJECTFILE=eda12131190311906.sln

# Configuration to use: Release or Debug
CONFIGURATION="Release"
#CONFIGURATION="Debug"

# The compiler to use.
CC=xbuild

# Properties will be the options pass to the compiler.
PROPERTIES = \
	/property:Configuration=$(CONFIGURATION) 

all: app

app: 
	$(CC) $(PROPERTIES) $(PROJFILE)
	
doxygen:
	cd ../sourcedoc/; make

rebuild: clean app

clean: clean-internal
	$(CC) $(PROPERTIES) /target:clean $(PROJECTFILE)

clean-internal:
	rm -fr ../bin/*
