using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{
	public Vector3 linearVelocity;
	public float angularVelocity;
	public GameObject target;
	public int mode;
	SteeringOutput steering;

	public void setAlign()
	{
		mode = 0;
	}
	public void setFace()
	{
		mode = 1;
	}
	public void setLook()
	{
		mode = 0;
	}

    // Update is called once per frame
    void Update()
    {
		//update position and rotation
		transform.position += linearVelocity * Time.deltaTime;
		transform.eulerAngles += new Vector3(0, angularVelocity * Time.deltaTime, 0);

		//update linear and angular velocities
		switch(mode)
		{
			case 0:
				Align myAlign = new Align();
				myAlign.character = this;
				myAlign.target = target;
				steering = myAlign.getSteering();
				if(steering != null)
				{
					linearVelocity += steering.linear * Time.deltaTime;
					angularVelocity += steering.angular * Time.deltaTime;
				}
				Debug.Log("Align");
				break;
			case 1:
				Face myFace = new Face();
				myFace.character = this;
				myFace.target = target;
				steering = myFace.getSteering();
				if (steering != null)
				{
					linearVelocity += steering.linear * Time.deltaTime;
					angularVelocity += steering.angular * Time.deltaTime;
				}
				Debug.Log("Face");
				break;
			case 2:
				LookWhereGoing myLook = new LookWhereGoing();
				myLook.character = this;
				myLook.target = target;
				steering = myLook.getSteering();
				if (steering != null)
				{
					linearVelocity += steering.linear * Time.deltaTime;
					angularVelocity += steering.angular * Time.deltaTime;
				}
				Debug.Log("Look");
				break;
		}
    }
}
