using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float vel = 10f;
    public Animator colisaoTiro;
    private Rigidbody2D rb;
    public SpriteRenderer sr;
    private PlayerController pc;

    private void Start()
    {
        pc = FindObjectOfType<PlayerController>(); 
        rb = GetComponent<Rigidbody2D>();
        colisaoTiro = GetComponent<Animator>();

        if (pc.viradoDireita)
        { 
            rb.velocity = transform.right * vel;
        }
        else
        { 
            rb.velocity = (transform.right * -1) * vel;
            sr.flipX = true;
        }
        destruirPorTempo();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        colisaoTiro.SetTrigger("colidiu");
        Debug.Log(collision.name);
        Destroy(gameObject);
    }

    private void destruirPorTempo()
    {
        Destroy(gameObject, 2f);
    }

}
