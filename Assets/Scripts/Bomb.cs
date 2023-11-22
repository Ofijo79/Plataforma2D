using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    SoundManager soundManager;
    Animator _animator;
    private float radio;
    private float fuerzaExplosion;


    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explosion()
    {
        Instiantate(efectoExplosion, transform.position, Quaternion.identity);
        Collider2D[] objetosIniciales = Physics2D.OverlapCircleAll(transform.position, radio);
    
        foreach(Collider2D colisionador in objetosIniciales)
        {
            Character _personaje = colisionador.GetComponent<Character>();
            if(_personaje != null)
            {
                
            }
        }
        
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radio);

        foreach (Collider2D colisionador in objetos)
        {
            Rigidbody2D rb2D = colisionador.GetComponent<Rigidbody2D>();
            if(rb2D != null)
            {
                Vector2 direccion = colisionador.transform.position - transform.position;
                float distancia = 1 + direccion.magnitude;
                float fuerzaFinal = fuerzaExplosion / distancia;
                rb2D.AddForce(direccion * fuerzaFinal);
            }
        }
    } 
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            //StartCoroutine("bombExplosion");
            _animator.SetBool("IsExploding", true);   
            soundManager.BombExplosion();
            //StopCoroutine("bombExplosion");
        }
    }

}
