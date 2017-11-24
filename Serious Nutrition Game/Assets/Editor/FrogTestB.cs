﻿namespace FrogTests
{
    using UnityEngine;
    using UnityEditor;
    using UnityEngine.TestTools;
    using NUnit.Framework;
    using System.Collections;

    [TestFixture]
    public class FrogTestB : MonoBehaviour
    {
        public FrogTestB()
        {

        }

        [UnityTest]
        public IEnumerator _State_Is_INITIAL_At_Start()
        {
            GameObject prefabSP1 = new GameObject("_State_Is_INITIAL_At_Start");
            TestablePondSpawnPoint script = prefabSP1.AddComponent<TestablePondSpawnPoint>();

            yield return null;

            Assert.AreEqual(script.state, TestablePondSpawnPoint.Mstates.INITIAL);
        }

        [TearDown]
        public void TearDown()
        {
            foreach (var go in GameObject.FindObjectsOfType<TestablePondSpawnPoint>())
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
