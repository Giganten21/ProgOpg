DIR = ../../library

lib.dll : roots.cs $(DIR)/qrgs.cs $(DIR)/matrix.cs $(DIR)/vector.cs
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) \
		$(addprefix -reference:,$(filter %.dll,$^))
