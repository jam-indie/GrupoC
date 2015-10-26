using UnityEngine;
using System.Collections;

public class Destoy : MonoBehaviour 
{
	void OnTriggerExit2D(Collider2D other)
	//void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject)
			Destroy(other.gameObject);
		
	}
}
