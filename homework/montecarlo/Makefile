DIR = ~/repository/ProgOpg/library

Out.txt : main.exe
	mono main.exe > Out.txt

plot.svg : plot.gpi Out.txt Makefile
	gnuplot $<

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

lib.dll : mc.cs $(DIR)/vector.cs
	mcs -target:library -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

clean:
	rm -f *.dll *.exe [oO]ut* *.svg
