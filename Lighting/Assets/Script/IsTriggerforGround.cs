using UnityEngine;
using System.Collections;

public class IsTriggerforGround : MonoBehaviour {

	BoxCollider2D box;
	SpriteRenderer sprite;

	// Use this for initialization
	void Start () 
	{
		box = GetComponent<BoxCollider2D>();
		sprite = GetComponent<SpriteRenderer>();
		box.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag == "Chao")
			sprite.enabled = false;
		else
			box.isTrigger = false;
	}
}
