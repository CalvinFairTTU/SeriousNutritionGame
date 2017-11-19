#! /bin/sh

project="SNG"
# PROJECTFOLDER = "Serious Nutrition Game"

#test scripts go here before the building


#build script only runs after successful tests

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
