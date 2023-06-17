DIR = ~/repository/ProgOpg/library

Out.txt : main.exe
	mono $< 1> $@ 2> log

sinplot.svg : sinplot.gpi Out.txt
	gnuplot $<

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

lib.dll : stepper.cs driver.cs $(DIR)/vector.cs genlist.cs
	mcs -target:library -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))
