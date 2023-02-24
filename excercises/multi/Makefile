N = 1e8
TIME =time --portability --append --output $@
Out.txt : main.exe parfor.exe Makefile
	>$@
	$(TIME) mono $< -terms:$N -threads:1 >>$@
	$(TIME) mono $< -terms:$N -threads:2 >>$@
	$(TIME) mono $< -terms:$N -threads:3 >>$@
	$(TIME) mono $< -terms:$N -threads:4 >>$@
main.exe : main.cs
	mcs $<
parfor.exe : parfor.cs
	mcs $<

N=5e8
test: out1 out2 out3 out4
out1: main.exe ; @mono main.exe -terms:$N -threads:1 >> $@
out2: main.exe ; @mono main.exe -terms:$N -threads:1 >> $@
out3: main.exe ; @mono main.exe -terms:$N -threads:1 >> $@
out4: main.exe ; @mono main.exe -terms:$N -threads:1 >> $@
