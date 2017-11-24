﻿namespace FrogTests
{
    using UnityEngine;
    using UnityEditor;
    using UnityEngine.TestTools;
    using NUnit.Framework;
    using System.Collections;

    [TestFixture]
    public class FrogTestA
    {
        public FrogTestA()
        {

        }

        [UnityTest]
        public IEnumerator _WaitCycleSpawn_GE_to_MinWaitSpawn()
        {
            var prefabSP = new GameObject("_WaitCycleSpawn_GE_to_MinWaitSpawn").AddComponent<TestablePondSpawnPoint>();
            yield return null;
            Assert.GreaterOrEqual(prefabSP.timer.getWaitCycleSpawn(), prefabSP.timer.getMinWaitCycleSpawn());
        }


        [TearDown]
        public void TearDown()
        {
            foreach (var go in GameObject.FindObjectsOfType<TestablePondSpawnPoint>())
            {
                Object.DestroyImmediate(go);
                Debug.Log("Object destroyed");
            }
            return;
        }

        //    [Test]
        //    public void FrogTestASimplePasses()
        //    {
        //        // Use the Assert class to test conditions.
        //    }

        //    // A UnityTest behaves like a coroutine in PlayMode
        //    // and allows you to yield null to skip a frame in EditMode
        //    [UnityTest]
        //    public IEnumerator FrogTestAWithEnumeratorPasses()
        //    {
        //        // Use the Assert class to test conditions.
        //        // yield to skip a frame
        //        yield return null;
        //    }
        
    }

}
