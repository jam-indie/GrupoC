using UnityEngine;
using System.Collections;

public class IsTriggerForCollisionPlayer : MonoBehaviour {

	Transform parent;
	// Use this for initialization
	void Start () 
	{
		parent = transform.parent;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Chao" && parent.GetComponent<Player>().actions == Status.jumping)
		{
			parent.GetComponent<Player>().actions = Status.running;
			parent.GetComponent<Player>().speed = 0;
		}
	}
}
