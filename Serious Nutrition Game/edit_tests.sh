#! /bin/sh


echo "Running script..."
D:/Programs/programs/Unity/Editor/Unity.exe \
-runEditorTests \
-projectPath=$(pwd) \
-editorTestsResultFile=$(pwd)/tests.xml \
-exit

echo "Finished..."
