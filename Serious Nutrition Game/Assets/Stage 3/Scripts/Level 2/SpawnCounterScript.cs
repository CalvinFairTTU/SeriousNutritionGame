using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SpawnCounterScript : MonoBehaviour {

    private int destCounter;
    //private int check;
    private int waitCycle;
    public int limit;
    public int setWaitCycle;
    

	// Use this for initialization
	void Start ()
    {
        this.destCounter = 0;
        waitCycle = setWaitCycle;
        Debug.Log("Start() destCounter = " + this.destCounter);
    }
	
	public int GetCounter()
    {
        return this.destCounter;
    }

    public void DecrementCounter(Collider2D food)
    {
        this.destCounter -= 1;
        //Debug.Log("DecrementCounter() destCounter = " + this.destCounter);
    }

    public void IncrementCounter()
    {
        this.destCounter += 1;
        //Debug.Log("IncrementCounter() destCounter = " + this.destCounter);
    }

    public void SetCounter(int target)
    {
        this.destCounter = target;
        // Debug.Log("SetCounter(" + target + ") destCounter = " + this.destCounter);        
    }
    
    //void LateUpdate()
    //{
    //    check = this.GetCounter();
    //    Debug.Log("waitCycle = " + waitCycle);
    //    if (check == 0 && waitCycle > 0)
    //    {
    //        waitCycle--;           
    //    }
    //    else if (check == 0 && waitCycle == 0)
    //    {
    //        this.SetCounter(limit);
    //        waitCycle = setWaitCycle;
    //    }
    //}
}
