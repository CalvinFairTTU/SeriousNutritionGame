namespace FrogTests
{
    using UnityEngine;
    using UnityEditor;
    using UnityEngine.TestTools;
    using NUnit.Framework;
    using System.Collections;

    [TestFixture]
    public class FrogTestB : MonoBehaviour
    {
        public GameObject prefabSP1;
        public TestablePondSpawnPoint script;

        public FrogTestB()
        {

        }

        [SetUp]
        public void PriorTo()
        {
            prefabSP1 = new GameObject("_State_Is_INITIAL_At_Start");
            script = prefabSP1.AddComponent<TestablePondSpawnPoint>();
        }

        [UnityTest]
        public IEnumerator _State_Is_INITIAL_At_Start()
        {
            yield return null;

            Assert.AreEqual(script.state, TestablePondSpawnPoint.Mstates.INITIAL);
        }

        [TearDown]
        public void TearDown()
        {
            foreach (var go in GameObject.FindObjectsOfType<GameObject>())
            {
                Object.DestroyImmediate(go);
                Debug.Log("Object destroyed after _State_Is_INITIAL_At_Start");
            }
            return;
        }

        //// Use this for initialization
        //void Start()
        //{

        //}

        //// Update is called once per frame
        //void Update()
        //{

        //}
    }

}
