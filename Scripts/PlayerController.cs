using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Animator anim;
	private Rigidbody2D rb2d;
	public Transform posPe;

	[HideInInspector] public bool tocaChao = false;
	[HideInInspector] public bool jump;
	
	public float Velocidade;
	public float ForcaPulo = 1000f;
	public float trocaArma;
	public int idArma = 0;
	
	[HideInInspector] public bool viradoDireita = true;
	
	public Image vida;

	void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();

	}
	void Update () {
		tocaChao = Physics2D.Linecast(transform.position, posPe.position, 1 << LayerMask.NameToLayer("chao"));
		if (Input.GetKeyDown("e") && tocaChao){
			idArma++;
			mudancaArma();
			Debug.Log(trocaArma);
		}
		if (Input.GetKeyDown("space") && tocaChao){
			anim.SetTrigger("pula");
			jump = true;
        }
		
	}

	void FixedUpdate(){
		float translationY = 0;
		float translationX = Input.GetAxis ("Horizontal") * Velocidade;
		transform.Translate (translationX, translationY, 0);
		transform.Rotate (0, 0, 0);
		if (translationX != 0 && tocaChao && idArma == 0) {
			anim.SetTrigger ("corre");
		} else {
			anim.SetTrigger("parado");
		}

		if (jump){
			rb2d.AddForce(new Vector2(0f, ForcaPulo));
			jump = false;
		}
		if (translationX > 0 && !viradoDireita) {
			Flip ();
		} else if (translationX < 0 && viradoDireita) {
			Flip();
		}

	}

	void Flip(){
		viradoDireita = !viradoDireita;
		Vector3 escala = transform.localScale;
		escala.x *= -1;
		transform.localScale = escala;
	}
	
	private void mudancaArma(){
	 idArma++;
        switch (trocaArma){
			case 1:
				if (trocaArma == 0 && tocaChao){
					anim.SetTrigger("corridaArmaAzul");
				}
				else if (trocaArma != 0 && tocaChao){
					anim.SetTrigger("standAzul");
                }
				break;
			case 2:
				if (trocaArma == 0 && tocaChao){
					anim.SetTrigger("corridaArmaLaranja"); 
				}
				else if (trocaArma != 0 && tocaChao){
					anim.SetTrigger("standLaranja");
				}
				break;
			default:
				idArma = 0;
				break;	       
        }
	}
}
