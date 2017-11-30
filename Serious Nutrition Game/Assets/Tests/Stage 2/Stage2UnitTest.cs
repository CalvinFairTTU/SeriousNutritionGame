﻿namespace StageTwoUnitTest
{
    using UnityEngine;
    using UnityEngine.TestTools;
    using NUnit.Framework;
    using System.Collections;

    [TestFixture]
    public class Stage2UnitTest
    {
        public GameObject item;
        public TestSpawnFood script;

        public Stage2UnitTest()
        {
        }

        [SetUp]
        public void prepareTest()
        {
            item = new GameObject("Test_Food");
            script = item.AddComponent<TestSpawnFood>();
        }

        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode

        [UnityTest]
        public IEnumerator Stage2UnitTestWithEnumeratorPasses()
        {
            yield return new WaitForSeconds(3f);
            Assert.True(script.food != null);
        }

        [TearDown]
        public void afterEverything()
        {
            foreach (var go in GameObject.FindObjectsOfType<GameObject>())
            {
                Debug.Log(go.ToString());
                Object.Destroy(go);
            }
            return;
        }
    }
}