Out.txt : main.exe Makefile
	echo 1 2 3 4 5 > inputfile.txt
	mono main.exe < inputfile.txt > Out.txt

main.exe : main.cs
	mcs -target:exe -out:$@ $(filter %.cs,$^) $(addprefix -refrencence, $(filter %.dll,$^))
