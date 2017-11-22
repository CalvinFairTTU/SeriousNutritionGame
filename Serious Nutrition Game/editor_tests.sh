#! /bin/sh


echo "Running script..."
D:/Programs/programs/Unity/Editor/Unity.exe \
-projectPath=$(pwd) \
-batchmode \
-nographics \
-runEditorTests \
-editorTestsResultFile \
-editorTestsVerboseLog

echo "Finished..."
