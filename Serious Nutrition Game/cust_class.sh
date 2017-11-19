#! /bin/sh

project="SNG"

echo "Running script..."
#/Applications/Unity/Unity.app/Contents/MacOS/Unity \
D:/Programs/programs/Unity/Editor/Unity.exe \
hello_world \
-projectPath=$(pwd) \
-exit \
-batchmode \
-executeMethod testNamespace.testComLineClass.printParamsMethod



echo "Script finished..."
