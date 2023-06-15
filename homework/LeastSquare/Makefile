DIR = ~/repository/ProgOpg/library

LeastFitPlot.svg : lsfitplot.gpi outdata.txt
	gnuplot $<	

outdata.txt : main.exe
	mono $< >  $@ 2>log


main.exe : main.cs least.dll gsqr.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

least.dll : least.cs gsqr.dll
	mcs -target:library -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

gsqr.dll: \
	$(DIR)/gsqr.cs \
	$(DIR)/matrix.cs \
	$(DIR)/vector.cs
	mcs -target:library -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

clean:
	$(RM) outdata* *.dll *.exe log* out* *.svg
