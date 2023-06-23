all: Out.txt Erfplot.svg
DIR = ../../library

out-erf.txt : main-erf.exe
	mono $< 1>  $@ 2> log

Out.txt : main.exe Makefile
	mono $< 1>  $@ 2> logerf

Erfplot.svg : erfplot.gpi out-erf.txt Makefile
	gnuplot $<

main-erf.exe : main-erf.cs lib.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

lib.dll : integrate.cs erf.cs $(DIR)/erf.cs 
	mcs -target:library -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

clean:
	rm -f *.exe *.dll *.svg out*
