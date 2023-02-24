default: Gamma.svg Lngamma.svg Erf.svg

Gamma.svg : gamma.gpi gamma.data factorial.data
	gnuplot $<

Lngamma.svg : gamma1.gpi lngamma.data factorial.data
	gnuplot $<

Erf.svg : erf.gpi error.data errorf.data
	gnuplot $<

errorf.data : main2.exe
	mono $< > $@

lngamma.data : main1.exe
	mono $< > $@

gamma.data : main.exe
	mono $< > $@

main2.exe : main2.cs sfuns.dll
	mcs -target:exe -out:$@ \
	$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

main1.exe: main1.cs sfuns.dll
	mcs -target:exe -out:$@ \
	$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

main.exe : main.cs sfuns.dll
	mcs -target:exe -out:$@ \
	$(addprefix -reference:,$(filter %.dll,$^)) $(filter %.cs,$^) 

sfuns.dll : gamma.cs erf.cs lngamma.cs
	mcs -target:library -out:$@ $^

factorial.data : Makefile
	>$@
	echo 0 1 >>$@
	echo 1 1 >>$@
	echo 2 2 >>$@
	echo 3 6 >>$@
	echo 4 24 >>$@
	echo 5 120 >>$@
#	echo 6 `echo '6*120' | bc` >>$@

error.data : Makefile
	>$@
	echo 0 0 >>$@
	echo 0.5 0.520499 >>$@
	echo 1 0.842700 >>$@
	echo 1.5 0.966105 >>$@
	echo 2 0.995322 >>$@
	echo 2.5 0.999593 >>$@
