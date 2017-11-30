namespace FrogTests
{
    using UnityEngine;
    using UnityEditor;
    using UnityEngine.TestTools;
    using NUnit.Framework;
    using System.Collections;

    [TestFixture]
    public class FrogTestA
    {
        public GameObject prefabSP;
        public TestablePondSpawnPoint script;
        public TestablePondSpawnPoint.TimerData timer;

        public FrogTestA()
        {

        }

        [SetUp]
        public void PriorTo()
        {
            prefabSP = new GameObject("_WaitCycleSpawn_GE_to_MinWaitSpawn");
            script = prefabSP.AddComponent<TestablePondSpawnPoint>();
            timer = script.timer;
            return;
        }

        [UnityTest]
        public IEnumerator _WaitCycleSpawn_GE_to_MinWaitSpawn()
        {
            yield return null;
            yield return null;
            Debug.Log("timer = " + timer);
            Assert.GreaterOrEqual(timer.getWaitCycleSpawn(), timer.getMinWaitCycleSpawn());
        }


        [TearDown]
        public void TearDown()
        {
            foreach (var go in GameObject.FindObjectsOfType<GameObject>())
            {
                Object.DestroyImmediate(go);
                Debug.Log("Object destroyed after _WaitCycleSpawn_GE_to_MinWaitSpawn");
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
