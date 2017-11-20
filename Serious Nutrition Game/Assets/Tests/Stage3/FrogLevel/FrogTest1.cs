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
        Debug.Log("WaitCycleSpawn = " + prefabSP.timer.getWaitCycleSpawn());
        Debug.Log("minWaitCycleSpawn = " + prefabSP.timer.getMinWaitCycleSpawn());
        Debug.Log("maxWaitCycleSpawn = " + prefabSP.timer.getMaxWaitCycleSpawn());
        Assert.GreaterOrEqual(prefabSP.timer.getWaitCycleSpawn(), prefabSP.timer.getMinWaitCycleSpawn());
    }

    [UnityTest]
    public IEnumerator _State_Is_Initial_At_Start()
    {
        var prefabSP = new GameObject().AddComponent<TestablePondSpawnPoint>();
        yield return null;
        Assert.AreEqual(prefabSP.state, TestablePondSpawnPoint.Mstates.INITIAL);
    }

    [UnityTest]
    public IEnumerator _State_Transition_To_Bubbling_After_Initial_Wait()
    {
        var prefabSP = new GameObject().AddComponent<TestablePondSpawnPoint>();
        var state = prefabSP.state;

        yield return new WaitUntil(()=> state != TestablePondSpawnPoint.Mstates.INITIAL);

        Assert.AreEqual(state, TestablePondSpawnPoint.Mstates.BUBBLING);
    }

    [UnityTest]
    public IEnumerator _State_Transition_To_FOODSPAWNED_After_Bubbling()
    {
        var prefabSP = new GameObject().AddComponent<TestablePondSpawnPoint>();
        var state = prefabSP.state;
        var spawnedfood = prefabSP.getSpawnedFood();

        yield return new WaitUntil(()=> spawnedfood == true);
        yield return null;

        Assert.AreEqual(state, TestablePondSpawnPoint.Mstates.FOODSPAWNED);
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
