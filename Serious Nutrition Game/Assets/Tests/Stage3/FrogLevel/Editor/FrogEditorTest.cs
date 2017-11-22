namespace FrogTests
{
    using UnityEngine;
    using UnityEditor;
    using UnityEngine.TestTools;
    using NUnit.Framework;
    using System.Collections;

    [TestFixture]
    public class FrogEditorTest
    {
        public FrogEditorTest()
        {
            
        }

        [UnityTest]
        public IEnumerator _WaitCycleSpawn_GE_to_MinWaitSpawn()
        {
            var prefabSP = new GameObject().AddComponent<TestablePondSpawnPoint>();
            yield return null;
            Assert.GreaterOrEqual(prefabSP.timer.getWaitCycleSpawn(), prefabSP.timer.getMinWaitCycleSpawn());
        }

        [UnityTest]
        public IEnumerator _State_Is_Initial_At_Start()
        {
            var prefabSP1 = new GameObject().AddComponent<TestablePondSpawnPoint>();
            yield return null;
            Assert.AreEqual(prefabSP1.state, TestablePondSpawnPoint.Mstates.INITIAL);
        }

        [UnityTest]
        public IEnumerator _State_Transition_To_Bubbling_After_Initial_Wait()
        {
            var prefabSP2 = new GameObject().AddComponent<TestablePondSpawnPoint>();
            if (prefabSP2.state != TestablePondSpawnPoint.Mstates.INITIAL)
            {
                prefabSP2.state = TestablePondSpawnPoint.Mstates.INITIAL;
            }
            var state = prefabSP2.state;
            while (state != TestablePondSpawnPoint.Mstates.INITIAL)
            {
                yield return null;
            }
            yield return null;
            Assert.AreEqual(prefabSP2.state, TestablePondSpawnPoint.Mstates.BUBBLING);
        }

        [UnityTest]
        public IEnumerator _State_Transition_To_FOODSPAWNED_After_Bubbling()
        {
            var prefabSP3 = new GameObject().AddComponent<TestablePondSpawnPoint>();

            while (prefabSP3.getSpawnedFood() != true)
            {
                yield return null;
                yield return null;
            }
            Assert.AreEqual(prefabSP3.state, TestablePondSpawnPoint.Mstates.FOODSPAWNED);
        }

        [TearDown]
        public void TearDown()
        {
            foreach (var go in GameObject.FindObjectsOfType<TestablePondSpawnPoint>())
            {
                Object.DestroyImmediate(go);
            }
            return;
        }



        //[Test]
        //public void FrogEditorTestSimplePasses() {
        //	// Use the Assert class to test conditions.
        //}

        //// A UnityTest behaves like a coroutine in PlayMode
        //// and allows you to yield null to skip a frame in EditMode
        //[UnityTest]
        //public IEnumerator FrogEditorTestWithEnumeratorPasses() {
        //	// Use the Assert class to test conditions.
        //	// yield to skip a frame
        //	yield return null;
        //}
    }
}

