using UnityEngine;
using System.Collections;

public enum Status {jumping, running};
public class Player : MonoBehaviour 
{
	public float speed;
	float oriSpeed;
	public float strong;
	public float timeForJump;
	float oriTimeForJump;
	public float timeForLanding;
	
	public bool inGround;
	bool landing;
	
	//KeyCode permite ter a disposição todas as teclas do teclado na unity
	public KeyCode jump;

	Animator anim;
	Rigidbody2D rb2D;
	public Status actions = Status.running;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		rb2D = GetComponent<Rigidbody2D>();
		oriSpeed = speed;
		oriTimeForJump = timeForJump;
		timeForLanding = oriTimeForJump;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(speed*Time.deltaTime, 0,0);
		
		//testa o click do mouse e se o chão está verdadeiro
		if(Input.GetKeyDown(jump) && inGround)
			actions = Status.jumping;

		switch(actions)
		{
		case Status.running:
			anim.SetBool("running",true);
			anim.SetBool("jumping",false);
			break;
			
		case Status.jumping:
			
			anim.SetBool("running",false);
			anim.SetBool("jumping",true);
			
			if(anim.GetBool("jumping") && inGround)
			{
				timeForJump -= Time.deltaTime;
				speed = 0;
				if(timeForJump < 0)
				{
					rb2D.MovePosition(rb2D.position + (Vector2.up*strong) * Time.deltaTime);
					speed = oriSpeed;
					//rb2D.AddForce(Vector3.up*strong, ForceMode2D.Impulse);	//adiciona força para a subida do personagem
				}
			}
			break;
		}
		if(inGround && !landing)
			timeForLanding -= Time.deltaTime;

		if(timeForLanding < 0 )
		{
			speed = oriSpeed;
			landing = true;
		}

	}	
	
	//testa a colisão do personagem com outro obj(other)
	void OnCollisionEnter2D(Collision2D other)
	{	
		//chama um gameObject que tenha uma tag com um nome
		if(other.gameObject.tag == "Chao")
		{
			inGround = true;
			actions = Status.running;
			timeForJump = oriTimeForJump;
		}
	}
	//testa a falta de colisão do personagem com outro obj(other)
	void OnCollisionExit2D(Collision2D other)
	{
		if(other.gameObject.tag == "Chao")
		{
			inGround = false;
			landing = false;
			timeForLanding = oriTimeForJump;
		}
	}
	
}
