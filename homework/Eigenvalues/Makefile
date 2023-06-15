DIR = ~/repository/ProgOpg/library

Ns = 3 4
Out.txt : main.exe
	>$@
	for N in $(Ns); do \
	echo $$N ;\
	MONO_PATH=$(DIR) mono main.exe -size:$$N >>$@ ;\
	done

main.exe : main.cs jacobi.dll $(DIR)/matrix.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

jacobi.dll : jacobi.cs $(DIR)/matrix.dll
	mcs -target:library -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))
