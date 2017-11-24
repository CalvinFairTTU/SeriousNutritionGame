namespace FrogTests
{
    using UnityEngine;
    using UnityEditor;
    using UnityEngine.TestTools;
    using NUnit.Framework;
    using System.Collections;

    [TestFixture]
    public class FrogTestD
    {
        public FrogTestD()
        {

        }

        [UnityTest]
        public IEnumerator _State_Transition_To_FOODSPAWNED_After_Bubbling()
        {
            var prefabSP3 = new GameObject("_State_Transition_To_FOODSPAWNED_After_Bubbling").AddComponent<TestablePondSpawnPoint>();

            while (prefabSP3.getSpawnedFood() != true)
            {
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
                Debug.Log("Object destroyed");
            }
            return;
        }
        //[Test]
        //public void FrogTestDSimplePasses()
        //{
        //    // Use the Assert class to test conditions.
        //}

        //// A UnityTest behaves like a coroutine in PlayMode
        //// and allows you to yield null to skip a frame in EditMode
        //[UnityTest]
        //public IEnumerator FrogTestDWithEnumeratorPasses()
        //{
        //    // Use the Assert class to test conditions.
        //    // yield to skip a frame
        //    yield return null;
        //}
    }
}

