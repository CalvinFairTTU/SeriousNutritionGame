using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class HippoTestA {

    public GameObject HT;
    public TestableSpawner script;
    public float T;

    public HippoTestA()
    {
       
    }

    [SetUp]
    public void PriorTo()
    {
        HT = new GameObject("HippoTestGO");
        script = HT.AddComponent<TestableSpawner>();
    }

    [UnityTest]
    public IEnumerator _Waits_Until_NextSpawn_To_Create_Object()
    {
        yield return null;
        yield return null;
        Assert.True(script.food != null);
    }

    [UnityTest]
    public IEnumerator _Spawns_Food_At_Given_X()
    {
        yield return new WaitUntil(() => script.food != null);
        Assert.AreEqual(script.whereToSpawn.x, script.food.transform.position.x);
    }

    //[UnityTest]
    //public IEnumerator _Force_Fail()
    //{
    //    yield return null;
    //    Assert.Fail();
    //}

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
    //public void HippoTestASimplePasses() {
    //	// Use the Assert class to test conditions.
    //}

    //// A UnityTest behaves like a coroutine in PlayMode
    //// and allows you to yield null to skip a frame in EditMode
    //[UnityTest]
    //public IEnumerator HippoTestAWithEnumeratorPasses() {
    //	// Use the Assert class to test conditions.
    //	// yield to skip a frame
    //	yield return null;
    //}
}
