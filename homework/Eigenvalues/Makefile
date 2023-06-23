DIR = ../../library

Ns = 3 4
Out.txt : main.exe
	>$@
	for N in $(Ns); do \
	echo $$N ;\
	MONO_PATH=$(DIR) mono main.exe -size:$$N >>$@ ;\
	done

main.exe : main.cs jacobi.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

jacobi.dll : jacobi.cs $(DIR)/matrix.cs $(DIR)/vector.cs
	mcs -target:library -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

clean :
	rm -f *.dll *.exe [oO]ut* *.svg
