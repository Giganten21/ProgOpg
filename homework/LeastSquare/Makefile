DIR = ../../library

LeastFitPlot.svg : lsfitplot.gpi outdata.txt
	gnuplot $<	

outdata.txt : main.exe
	mono $< >  $@

main.exe : main.cs lib.dll 
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

lib.dll : least.cs $(DIR)/qrgs.cs $(DIR)/vector.cs $(DIR)/matrix.cs
	mcs -target:library -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

clean:
	$(RM) outdata* *.dll *.exe log* out* *.svg
