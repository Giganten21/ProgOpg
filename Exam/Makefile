all: Out.txt Compare.svg
DIR = ../library


Out.txt : main.exe
	mono $< > $@

Compare.svg : plot.gpi stopwatch.txt
	gnuplot $<

stopwatch.txt : timeit.exe
	mono $< > $@

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

timeit.exe : timeit.cs lib.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

lib.dll : jacobi.cs $(DIR)/matrix.cs $(DIR)/vector.cs $(DIR)/qrgs.cs
	mcs -target:library -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

clean :
	rm -f *.dll *.exe [oO]ut* *.svg *.txt
