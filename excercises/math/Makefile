Out.txt : Main.exe
	mono Main.exe > Out.txt

Main.exe : Main.cs sfuns.dll
	mcs -target:exe -out:Main.exe -reference:sfuns.dll Main.cs

sfuns.dll : sfuns.cs
	mcs -target:library -out:sfuns.dll sfuns.cs

clean:
	rm -f Out.txt Main.exe

