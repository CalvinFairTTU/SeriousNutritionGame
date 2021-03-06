#! /bin/sh

project="SNG"
# PROJECTFOLDER = "Serious Nutrition Game"

#test scripts go here before the building

echo "Running tests..."

/Applications/Unity/Unity.app/Contents/MacOS/Unity \
-runTests \
-projectPath=$(pwd) \
-testResults \
-testPlatform playmode  \
-batchmode \
-nographics

if [ $? -eq 0 ]
then
  echo All tests passed...
else
  echo $?
  echo One or more tests failed.
fi

# find -name *.xml
# cat TestResults*.xml
# cat $(pwd)/tests.xml


echo "Attempting to build $project for Windows"
# D:/Programs/programs/Unity/Editor/Unity.exe \
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath=$(pwd) \
  -buildWindows64Player "$(pwd)/$project.exe" \
  -quit

# echo "Attempting to build $project for OS X"
# C:\Program Files\Unity\Editor\Unity.exe \
#   -batchmode \
#   -nographics \
#   -silent-crashes \
#   -logFile $(pwd)/unity.log \
#   -projectPath $(pwd) \
#   -buildOSXUniversalPlayer "$(pwd)/Build/osx/$project.app" \
#   -quit

echo 'Logs from build'
cat $(pwd)/unity.log
echo 'Did we make it this time?'
