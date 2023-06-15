

out.txt : main.exe
	mono main.exe > out.txt

main.exe : main.cs spline.dll
	mcs -target:library -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

spline.dll : spline.cs
	mcs -target:library -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))

clean:
	rm -f *.exe *.dll out*
