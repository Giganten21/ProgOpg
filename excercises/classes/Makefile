Out.txt : Main.exe
	mono Main.exe > Out.txt

Main.exe : Main.cs vec.dll
	mcs Main.cs -reference:vec.dll -target:exe -out:Main.exe

vec.dll : vec.cs
	mcs $< -target:library -out:$@

