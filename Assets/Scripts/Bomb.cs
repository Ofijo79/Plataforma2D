using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    SoundManager soundManager;
    Animator _animator;
    PolygonCollider2D polygonCollider;


    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        _animator = GetComponent<Animator>();
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*IEnumerator bombExplosion()
    {
        
    }*/
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
