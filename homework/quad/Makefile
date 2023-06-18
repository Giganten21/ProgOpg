erfplot.svg : erfplot.gpi
	gnuplot $<

out.txt : main.exe
	mono $< >  $@ 2>log

out-erf.txt : main-erf.exe
	mono $< >  $@ 2>logerf

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

main-erf.exe : main-erf.cs lib.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

lib.dll : integrate.cs erf.cs
	mcs -target:library -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

clean:
	rm -f *.exe *.dll *.svg out*
