using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public float speed;
	public float strong;
	
	public bool EstaNoChao;
	
	//KeyCode permite ter a disposição todas as teclas do teclado na unity
	public KeyCode right;
	public KeyCode left;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		//testa o click do mouse e se o chão está verdadeiro
		if(Input.GetMouseButtonDown(0) && EstaNoChao == true)
		{    
			//adiciona força para a subida do personagem
			GetComponent<Rigidbody2D>().AddForce(transform.up*strong);			
		}
			
	}	
	
	//testa a colisão do personagem com o chão 
	void OnCollisionEnter2D(Collision2D other)
	{	
		//chama um gameObject que tenha uma tag com um nome
		//o nome varia de cada gameObject 
		if(other.gameObject.tag == "Chao")
			EstaNoChao = true;
		
	}
	//testa a falta de colisão do personagem com o chão
	void OnCollisionExit2D(Collision2D other)
	{
		if(other.gameObject.tag == "Chao")
			EstaNoChao = false;
		
	}
	
}
