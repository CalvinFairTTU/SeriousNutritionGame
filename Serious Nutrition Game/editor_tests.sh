#! /bin/sh


echo "Running script..."
D:/Programs/programs/Unity/Editor/Unity.exe \
-projectPath=$(pwd) \
-batchmode \
-nographics \
-executeMethod Test.FrogTest1._WaitCycleSpawn_GE_to_MinWaitSpawn \
-resultFilePath=$(pwd)/temp.xml \
-exit

echo "Finished..."
