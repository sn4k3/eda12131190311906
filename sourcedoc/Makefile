#
# Estruturas de Dados e Algoritmos (EDA) - Project I
# Tiago Conceição Nº 11903
# Gonçalo Lampreia Nº 11906
# https://code.google.com/p/eda12131190311906/
#
# Makefile - build and compile project
#

# The compiler to use.
CC=doxygen

all: doxygen refman.pdf
	
doxygen:
	$(CC)

refman.pdf:
	cd latex; make
	cp -f latex/refman.pdf Documentation.pdf

rebuild: clean app

clean: clean-internal
	

clean-internal:
	rm -fr ../html/*
	rm -fr ../latex/*
