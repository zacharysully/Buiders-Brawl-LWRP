using UnityEngine;
using System.Collections;

public class StairDismount : MonoBehaviour {
	//Declare a member variables for distributing the impacts over several frames
	float impactEndTime=0;
	Rigidbody impactTarget=null;
    Rigidbody[] rigidBodies;

    Vector3 impact;
	// Use this for initialization
	void Start () {

        //Get all the rigid bodies that belong to the ragdoll
        rigidBodies = GetComponentsInChildren<Rigidbody>();
		
		//Add the RagdollPartScript to all the gameobjects that also have the a rigid body
		foreach (Rigidbody body in rigidBodies)
		{
			RagdollPartScript rps=body.gameObject.AddComponent<RagdollPartScript>();
			
			//Set the scripts mainScript reference so that it can access
			//the score and scoreTextTemplate member variables above
			rps.mainScript=this;
		}
	}
	
	// Update is called once per frame
	void Update () {
        //if left mouse button clicked
        if (Input.GetKeyDown(KeyCode.E))
        {

            //find the RagdollHelper component and activate ragdolling
            RagdollHelper helper = GetComponent<RagdollHelper>();
            helper.ragdolled = true;

            //set the impact target to whatever the ray hit
            impactTarget = rigidBodies[0];

            //the impact will be reapplied for the next 250ms
            //to make the connected objects follow even though the simulated body joints
            //might stretch
            impactTarget.AddForce(-transform.forward * 0.5f, ForceMode.Force);
        }
		
		//Pressing space makes the character get up, assuming that the character root has
		//a RagdollHelper script
		if (Input.GetKeyDown(KeyCode.Space))
		{
			RagdollHelper helper=GetComponent<RagdollHelper>();
			helper.ragdolled=false;
		}	
		
		//Check if we need to apply an impact
		if (Time.time<impactEndTime)
		{
			
		}
	}
}
