#
# Estruturas de Dados e Algoritmos (EDA) - Project I
# Tiago Concei��o N� 11903
# Gon�alo Lampreia N� 11906
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
