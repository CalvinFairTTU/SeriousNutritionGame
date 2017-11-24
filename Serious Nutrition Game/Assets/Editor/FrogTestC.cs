namespace FrogTests
{
    using UnityEngine;
    using UnityEditor;
    using UnityEngine.TestTools;
    using NUnit.Framework;
    using System.Collections;

    [TestFixture]
    public class FrogTestC
    {
        public FrogTestC()
        {

        }

        [UnityTest]
        public IEnumerator _State_Transition_To_Bubbling_After_Initial_Wait()
        {
            var prefabSP2 = new GameObject("_State_Transition_To_Bubbling_After_Initial_Wait").AddComponent<TestablePondSpawnPoint>();
            if (prefabSP2.state != TestablePondSpawnPoint.Mstates.INITIAL)
            {
                prefabSP2.state = TestablePondSpawnPoint.Mstates.INITIAL;
            }
            var state = prefabSP2.state;
            while (state != TestablePondSpawnPoint.Mstates.INITIAL)
            {
                yield return null;
                state = prefabSP2.state;
            }
            Assert.AreEqual(prefabSP2.state, TestablePondSpawnPoint.Mstates.BUBBLING);
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

        //[Test]
        //public void FrogTestCSimplePasses()
        //{
        //    // Use the Assert class to test conditions.
        //}

        //// A UnityTest behaves like a coroutine in PlayMode
        //// and allows you to yield null to skip a frame in EditMode
        //[UnityTest]
        //public IEnumerator FrogTestCWithEnumeratorPasses()
        //{
        //    // Use the Assert class to test conditions.
        //    // yield to skip a frame
        //    yield return null;
        //}
    }

}

