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
        public GameObject prefabSP3;
        public TestablePondSpawnPoint script;

        public FrogTestD()
        {

        }

        [SetUp]
        public void PriorTo()
        {
            prefabSP3 = new GameObject("_State_Transition_To_FOODSPAWNED_After_Bubbling");
            script = prefabSP3.AddComponent<TestablePondSpawnPoint>();
        }

        [UnityTest]
        public IEnumerator _State_Transition_To_FOODSPAWNED_After_Bubbling()
        {
            while (script.getSpawnedFood() != true)
            {
                yield return null;
            }
            yield return null;
            Assert.AreEqual(script.state, TestablePondSpawnPoint.Mstates.FOODSPAWNED);
        }

        [TearDown]
        public void TearDown()
        {
            foreach (var go in GameObject.FindObjectsOfType<GameObject>())
            {
                Object.DestroyImmediate(go);
                Debug.Log("Object destroyed after _State_Transition_To_FOODSPAWNED_After_Bubbling");
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

