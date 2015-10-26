using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour 
{
	public KeyCode pause;
	public KeyCode SairPause;

	// Use this for initialization
	void Start () 
	{}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(pause))
			Time.timeScale = 0;
	

		if(Input.GetKey(SairPause))
			Time.timeScale = 1;

	
	}
}
