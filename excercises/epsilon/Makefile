Out.txt : main.cs
	mono main.exe > Out.txt

main.exe : main.cs sfuns.dll
	mcs -target:exe -out:$@ \
		$(addprefix -reference:,$(filter %.dll,$^)) \
		$(filter %.cs,$^)

sfuns.dll : sfuns.cs
	mcs -target:library -out:$@ $<
clean : 
	rm -f *.exe *.dll [Oo]ut* log*
