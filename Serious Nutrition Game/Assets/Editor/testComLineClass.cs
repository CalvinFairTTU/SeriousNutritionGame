using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using FrogTest;


namespace testNamespace
{

    class testComLineClass {

        public static void printParamsMethod()
        {
            //string[] comline;
            //comline = Environment.GetCommandLineArgs();

            FrogTest1 frog = new FrogTest1();
            frog._State_Is_Initial_At_Start();
            frog._State_Transition_To_Bubbling_After_Initial_Wait();
            frog._State_Transition_To_FOODSPAWNED_After_Bubbling();
            frog._WaitCycleSpawn_GE_to_MinWaitSpawn();

            EditorApplication.Exit(0);
        }
	
    }

}

