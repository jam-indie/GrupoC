using UnityEngine;
using System.Collections;

public class IsTriggerForFire : MonoBehaviour {

	public Transform children;
	SpriteRenderer anim;
	// Use this for initialization
	void Start () 
	{
		children = transform.GetChild(0);
		anim = children.GetComponent<SpriteRenderer>();
		anim.enabled = false;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
			anim.enabled = true;
	}
}
