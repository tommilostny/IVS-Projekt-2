# spustí progam
all: run 

# zabalí projekt tak, aby mohl být odevzdán
pack: clean
	if exist .\Setup_Calculator\Debug\ (xcopy Setup_Calculator\Debug\Setup_Calculator.msi ..\..\xrivol01_xmilos02_xponiz01_xpaulr01\install\\ /Q && rmdir /Q /S .\Setup_Calculator\Debug)
	if exist .\doc (xcopy doc ..\..\xrivol01_xmilos02_xponiz01_xpaulr01\doc\\ /E/I/H/Q && rmdir /Q /S .\doc)
	xcopy .. ..\..\xrivol01_xmilos02_xponiz01_xpaulr01\repo\\ /E/I/H/Q
	rm -f .\xrivol01_xmilos02_xponiz01_xpaulr01.zip
	powershell Compress-Archive -Path ..\..\xrivol01_xmilos02_xponiz01_xpaulr01 -DestinationPath xrivol01_xmilos02_xponiz01_xpaulr01.zip
	rmdir /Q /S ..\..\xrivol01_xmilos02_xponiz01_xpaulr01

# smaže všechny soubory, co nemají být odevzdány
clean:
	if exist ..\.vs\                      rmdir /Q /S ..\.vs
	if exist .\.vs\                       rmdir /Q /S .\.vs
	if exist .\TestResults\               rmdir /Q /S .\TestResults
	if exist .\Calculator\bin\            rmdir /Q /S .\Calculator\bin
	if exist .\Calculator\obj\            rmdir /Q /S .\Calculator\obj
	if exist .\MathLib\bin\               rmdir /Q /S .\MathLib\bin
	if exist .\MathLib\obj\               rmdir /Q /S .\MathLib\obj
	if exist .\MathLibraryTests\bin\      rmdir /Q /S .\MathLibraryTests\bin
	if exist .\MathLibraryTests\obj\      rmdir /Q /S .\MathLibraryTests\obj
	if exist .\Profiling\bin\             rmdir /Q /S .\Profiling\bin
	if exist .\Profiling\obj\             rmdir /Q /S .\Profiling\obj
	if exist .\Setup_Calculator\Release\  rmdir /Q /S .\Setup_Calculator\Release

# spustí program
run:
	.\Calculator\bin\Debug\Calculator.exe

# spustí program pro výpočet směrodatné odchylky s ukázkovým testovacím vstupem
profile:
	.\Profiling\bin\Debug\netcoreapp3.1\Profiling.exe < Profiling\Input\10.txt
	.\Profiling\bin\Debug\netcoreapp3.1\Profiling.exe < Profiling\Input\100.txt
	.\Profiling\bin\Debug\netcoreapp3.1\Profiling.exe < Profiling\Input\1000.txt

# vypíše nápovědu s popisem, co je potřeba udělat před spuštěním programu
help:
	@echo Before running the Calculator app you need to open "Calculator.sln" solution file in Visual Studio and build the project.
	@echo Loading and building "Setup_Calculator" project requires "Microsoft Visual Studio Installer Projects" extension installed.