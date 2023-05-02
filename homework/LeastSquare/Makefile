DIR = ~/repository/ProgOpg/library

least.dll : least.cs $(DIR)/gsqr.dll
	mcs -target:library -out:$@ \
		$(filter %.cd,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))
	
