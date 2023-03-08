Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs matrix.dll qrgs.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

qrgs.dll : qrgs.cs matrix.dll
	mcs -target:library -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

