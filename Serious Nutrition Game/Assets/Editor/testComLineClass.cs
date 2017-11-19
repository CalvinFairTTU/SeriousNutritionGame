using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


namespace testNamespace
{

    class testComLineClass {

        public static void printParamsMethod()
        {
            string[] comline;
            comline = Environment.GetCommandLineArgs();

            

            EditorApplication.Exit(0);
        }
	
    }

}

