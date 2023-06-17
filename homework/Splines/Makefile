FMT = svg
OPT = font "Arial,20" size 1024,600
PLOT = plot
PLOTFILE=$(PLOT).$(FMT)
DATA = out.txt
ECHO=/bin/echo

plot.svg: plot.gpi out.txt
	gnuplot $<

$(DATA): main.exe
	mono $< >$@

main.exe: main.cs spline.dll
	mcs $< -reference:$(lastword $^)

spline.dll: spline.cs
	mcs $< -target:library -out:$@

clean:
	rm -f *.exe *.dll $(PLOTFILE) $(DATA) *.svg out*
