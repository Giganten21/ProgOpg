DIR = ../../library

Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

lib.dll : qnewton.cs $(DIR)/matrix.cs $(DIR)/vector.cs
	mcs -target:library -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

clean :
	rm -f *.dll *.exe [oO]ut* *.svg
