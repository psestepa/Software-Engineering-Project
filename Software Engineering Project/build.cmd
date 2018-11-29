csc -lib:lib -reference:nunit.framework.dll /target:library -out:assign1.dll  Controllers\RegisterController.cs test\*.cs
lib\nunitlite-runner.exe assign1.dll
del assign1.dll
del *.xml
