using UnityEngine;
using System.Collections;

public class inimigo : MonoBehaviour 
{
	GameObject player;
	public float Velocidade;
	public float strong;
	public float distSighted;
	public float distAtk;
	public bool PlayerP = false;
	public bool EstaNoChao =false;
	public bool TocarCabeca = false;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player)
		{
			float dist = Vector3.Distance(player.transform.position, transform.position);
			//print ("distancia do heroi:" + dist);
			if(dist < distSighted)
				transform.Translate(Velocidade*Time.deltaTime, 0, 0);

			if(dist < distAtk && EstaNoChao)
				GetComponent<Rigidbody2D>().AddForce (transform.up*strong);
		}


		//if(EstaNoChao)
		//GetComponent<Rigidbody2D>().AddForce(transform.up*strong);




		if(TocarCabeca)
			Destroy(this.gameObject);

	}

	void OnCollisionEnter2D(Collision2D other)
	{	
		//chama um gameObject que tenha uma tag com um nome
		//o nome varia de cada gameObject 
		if(other.gameObject.tag == "Chao")
			EstaNoChao = true;

		if(other.gameObject == player)
			Application.LoadLevel(0);
			//TocarCabeca = true;
		/* esse teste esta comentado pois no jogo dessa maquina o player nao tem um colizor separado para a cabeça
		if(other.gameObject.tag == "Cabeca")
			TocarCabeca = true;	
			*/

	}

	void OnCollisionExit2D(Collision2D other)
	{
		if(other.gameObject.tag == "Chao")
			EstaNoChao = false;
		
	}

	void OnTriggerExit2D(Collider2D other)
	{	
		//chama um gameObject que tenha uma tag com um nome
		//o nome varia de cada gameObject 
		if(other.gameObject.tag == "Player")
		{
			PlayerP = true;

			Debug.Log ("oi");
		}

	}

	/*void OnCollisionExit2D(Collision2D other)
	{
		if(other.gameObject.tag == "Cabeça")
			//Destroy(gameObject, 5f);
		
	}*/
}
