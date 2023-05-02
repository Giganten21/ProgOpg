#RM = rm ---force
all : Out.txt

Out.txt : cmdinput.exe stinput.exe fileinput.exe inputfile.txt Makefile
	>$@
	echo "From cmdline:" >>$@
	mono cmdinput.exe -numbers:1,2,3,4,5 1>>$@ 2>>log
	echo "From standart input" >>$@
	mono stinput.exe <inputfile.txt 1>>$@ 2>> Out.txt
	echo "From inputfile" >>$@
	mono fileinput.exe -input:inputfile.txt -output:outfile.txt \
		1>>$@ 2>>log
	cat outfile.txt >> $@

cmdinput.exe : cmdinput.cs
	mcs -target:exe -out:$@ \
	$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

stinput.exe : stinput.cs
	mcs -target:exe -out:$@ \
	$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

fileinput.exe : fileinput.cs
	mcs -target:exe -out:$@ \
	$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

inputfile.txt : Makefile
	echo 2 >$@
	echo 3 >>$@
	echo 4 >>$@

clean:
	$(RM) *.exe *.dll [Oo]ut* log*
