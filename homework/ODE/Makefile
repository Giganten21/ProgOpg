DIR = ~/repository/ProgOpg/library
all: sinplot.svg fricplot.svg


Out.txt : main.exe
	mono $< 1> $@ 2> log

Out-fric.txt : main_fric.exe
	mono $< 1> $@ 2> logfric

sinplot.svg : sinplot.gpi Out.txt Makefile
	gnuplot $<

fricplot.svg : fricplot.gpi Out-fric.txt Makefile
	gnuplot $<

main_fric.exe : main_fric.cs lib.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

lib.dll : stepper.cs driver.cs $(DIR)/vector.cs genlist.cs
	mcs -target:library -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

clean:
	rm -f *.dll *.exe [oO]ut* *.svg [Ll]og*
