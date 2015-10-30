using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Instantiate : MonoBehaviour
{
	List<Transform> blocos;
	public Transform bloco0;
	public Transform bloco1;
	public Transform bloco2;
	public Transform bloco3;
	public Transform bloco4;
	public Transform bloco5;
	public Transform bloco6;
	public Transform bloco7;
	public Transform bloco8;

	Transform blocoSurpresa;

	public int numBlc;
	public float spaceBetweenBlocs;
	public Vector3 reg;
	bool create;

	// Use this for initialization
	void Start ()
	{
		blocos = new List<Transform>();
		blocos.Add(bloco0);
		blocos.Add(bloco1);
		blocos.Add(bloco2);
		/*blocos.Add(bloco3);
		blocos.Add(bloco4);
		blocos.Add(bloco5);
		blocos.Add(bloco6);
		blocos.Add(bloco7);
		blocos.Add(bloco8);*/

		/*blocoSurpresa = blocos[numBlc];
		tam = blocoSurpresa.FindChild("Fundo").GetComponent<SpriteRenderer>();*/


	}
	
	// Update is called once per frame
	void Update () 
	{
		//reg.x = tam.bounds.extents.x;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "MainCamera" && !create)
		{

			numBlc = Random.Range(0, blocos.Count);
			blocoSurpresa = blocos[numBlc];

			SpriteRenderer tam;
			tam = blocoSurpresa.FindChild("Fundo").GetComponent<SpriteRenderer>();
			reg.x = transform.position.x + (spaceBetweenBlocs*tam.bounds.extents.x);
			Instantiate(blocoSurpresa,reg, Quaternion.identity);
			create = true;
		}
	}
}
