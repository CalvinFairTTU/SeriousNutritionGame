namespace WhackTest
{
    using UnityEngine;
    using UnityEngine.TestTools;
    using NUnit.Framework;
    using System.Collections;


    [TestFixture]
    public class WhackASnackTestA
    {

        public GameObject SP, NewObj;
        public TestableSpawnScript script;
        public Transform tr;
        public int index;

        public WhackASnackTestA()
        {

        }

        [SetUp]
        public void PriorTo()
        {
            SP = new GameObject("_Instantiates_Object_To_Transform_In_Array");
            script = SP.AddComponent<TestableSpawnScript>();
        }

        [UnityTest]
        public IEnumerator _Instantiates_Object_To_Transform_In_Array_X()
        {
            yield return new WaitUntil(() => script.objectCreated == true);
            yield return null;
            index = script.spawnIndex;
            NewObj = script.spawns[index];
            tr = NewObj.transform;
            Assert.AreEqual(script.TheNewObject.transform.position.x, NewObj.transform.position.x);
        }

        [UnityTest]
        public IEnumerator _Instantiates_Object_To_Transform_In_Array_Y()
        {
            yield return new WaitUntil(() => script.objectCreated == true);
            yield return null;
            index = script.spawnIndex;
            NewObj = script.spawns[index];
            tr = NewObj.transform;
            Assert.AreEqual(script.TheNewObject.transform.position.y, NewObj.transform.position.y);
        }

        [UnityTest]
        public IEnumerator _Instantiates_Object_To_Transform_In_Array_Z()
        {
            yield return new WaitUntil(() => script.objectCreated == true);
            yield return null;
            index = script.spawnIndex;
            NewObj = script.spawns[index];
            tr = NewObj.transform;
            Assert.AreEqual(script.TheNewObject.transform.position.z, NewObj.transform.position.z);
        }

        [TearDown]
        public void AfterEveryTest()
        {
            foreach (var go in GameObject.FindObjectsOfType<GameObject>())
            {
                Debug.Log("Destroying object: " + go.ToString());
                Object.Destroy(go);
            }
            return;
        }

        //[Test]
        //public void WhackASnackTestASimplePasses() {
        //	// Use the Assert class to test conditions.
        //}

        //// A UnityTest behaves like a coroutine in PlayMode
        //// and allows you to yield null to skip a frame in EditMode
        //[UnityTest]
        //public IEnumerator WhackASnackTestAWithEnumeratorPasses() {
        //	// Use the Assert class to test conditions.
        //	// yield to skip a frame
        //	yield return null;
        //}
    }
}

