# spustí progam
all: run 

# zabalí projekt tak, aby mohl být odevzdán
pack: clean
	powershell Compress-Archive -Path ..\ -DestinationPath ..\xrivol01_xmilos02_xponiz01_xpaulr01.zip

# smaže všechny soubory, co nemají být odevzdány
clean:
	if exist ..\doxygen\             rmdir /Q /S ..\doxygen
	if exist ..\.vs\                 rmdir /Q /S ..\.vs
	if exist .\.vs\                  rmdir /Q /S .\.vs
	if exist .\TestResults\          rmdir /Q /S .\TestResults
	if exist .\Calculator\bin\       rmdir /Q /S .\Calculator\bin
	if exist .\Calculator\obj\       rmdir /Q /S .\Calculator\obj
	if exist .\MathLib\bin\          rmdir /Q /S .\MathLib\bin
	if exist .\MathLib\obj\          rmdir /Q /S .\MathLib\obj
	if exist .\MathLibraryTests\bin\ rmdir /Q /S .\MathLibraryTests\bin
	if exist .\MathLibraryTests\obj\ rmdir /Q /S .\MathLibraryTests\obj
	if exist .\Profiling\bin\        rmdir /Q /S .\Profiling\bin
	if exist .\Profiling\obj\        rmdir /Q /S .\Profiling\obj
	rm -f ..\xrivol01_xmilos02_xponiz01_xpaulr01.zip

# spustí program
run:
	.\Calculator\bin\Debug\Calculator.exe

# spustí program pro výpočet směrodatné odchylky s ukázkovým testovacím vstupem
profile:
	.\Profiling\bin\Debug\netcoreapp3.1\Profiling.exe

# vypíše nápovědu s popisem, co je potřeba udělat před spuštěním programu
help:
	@echo Before running the Calculator app you need to open "Calculator.sln" solution file in Visual Studio and build the project.
