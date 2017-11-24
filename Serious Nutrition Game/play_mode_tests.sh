#! /bin/sh

echo "Running script..."

D:/Programs/programs/Unity/Editor/Unity.exe \
-runTests \
-projectPath=$(pwd) \
-testResults=$(pwd)/tests.xml \
-testPlatform playmode  \
-batchmode

echo "Finished..."

cat TestResults*.xml



# Unity.exe -runTests -projectPath path/to/project -testResults path/to/results.xml -testPlatform WSAPlayer -batchmode
