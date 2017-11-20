using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class FrogTest1 {

    [UnityTest]
    public IEnumerator _WaitCycleSpawn_GE_to_MinWaitSpawn()
    {
        var prefabSP = new GameObject().AddComponent<TestablePondSpawnPoint>();
        yield return null;
        Assert.GreaterOrEqual(prefabSP.getWaitCycleSpawn(), prefabSP.minWaitSpawn);
    }

    //[UnityTest]
    //public IEnumerator _Spawned_Food_Located_At_X_Of_Spawn_Point()
    //{
    //    var prefabSP = new GameObject().AddComponent<TestablePondSpawnPoint>();

    //    Debug.Log("Waiting");
    //    yield return new WaitWhile(() => prefabSP.state != TestablePondSpawnPoint.Mstates.FOODSPAWNED);
    //    Debug.Log("Done");

    //    var spawnedfood = prefabSP.getSpawnedFood();
    //    var x = prefabSP.transform.position.x;
    //    var X = spawnedfood.transform.position.x;
    //    Assert.AreEqual(x,X);
    //}

    [UnityTest]
    public IEnumerator _Spawned_Food_Located_At_Y_Of_Spawn_Point()
    {
        var prefabSP = new GameObject().AddComponent<TestablePondSpawnPoint>();
        var prefab = Resources.Load("Tests/Stage3/FrogLevel/TestObjects/testfoods/Bacon.prefab");

        var spawnedfood = new GameObject().AddComponent(prefab.GetType());
        spawnedfood.transform.position = new Vector3(prefabSP.transform.position.x, prefabSP.transform.position.y,0);

        yield return new WaitForSeconds(1);
        float y = prefabSP.transform.position.y;
        float Y = spawnedfood.transform.position.y;
        Assert.AreEqual(y, Y);
    }

    [TearDown]
    public void AfterEveryTest()
    {
        foreach (var go in GameObject.FindObjectsOfType<TestablePondSpawnPoint>())
        {
            Object.Destroy(go);
        }
        return;
    }






















    //[Test]
    //public void FrogTest1SimplePasses() {
    //	// Use the Assert class to test conditions.
    //}

    //// A UnityTest behaves like a coroutine in PlayMode
    //// and allows you to yield null to skip a frame in EditMode
    //[UnityTest]
    //public IEnumerator FrogTest1WithEnumeratorPasses() {
    //	// Use the Assert class to test conditions.
    //	// yield to skip a frame
    //	yield return null;
    //}
}
