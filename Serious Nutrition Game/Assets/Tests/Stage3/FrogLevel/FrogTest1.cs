﻿using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class FrogTest1 {

    [UnityTest]
    public IEnumerator _Spawned_Food_Located_At_Spawn_Point()
    {
        var spawnpoint = new GameObject().AddComponent<SpawnPoint1>();
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
