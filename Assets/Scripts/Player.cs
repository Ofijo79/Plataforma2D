using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [Tooltip("Controla la velocidad de movimiento del PJ")]
    [SerializeField]float _playerSpeed = 5;
    float _playerInputX;
    //float _playerInputY;
    [Tooltip("Controla la fuerza de salto del PJ")]
    [SerializeField]float _jumpForce = 5;

    //SpriteRenderer spriterenderer;
    [SerializeField] PlayableDirector _director;

    Rigidbody2D _rBody2D;

    //GroundSensor _sensor;

    [SerializeField]Animator _animator;
    SoundManager soundManager;
    GameManager gameManager;
     

    
    // Start is called before the first frame update
    void Awake()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //_sensor = GetComponentInChildren<GroundSensor>();
        //spriterenderer = GetComponentInChildren<SpriteRenderer>();

        //Debug.Log(GameManager.instance.vidas);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if(Input.GetButtonDown("Jump") && GroundSensor._isGrounded)
        {
            Jump();
            _animator.SetBool("IsJumping", true);
            SoundManager.instance.JumpSFX();
        }
        if(Input.GetButtonDown("Fire2"))
        {
            _director.Play();
        }
    }

    void FixedUpdate() 
    {
        //_rBody2D.AddForce(new Vector2(_playerInputX * _playerSpeed, 0), ForceMode2D.Impulse);

        _rBody2D.velocity = new Vector2(_playerInputX * _playerSpeed, _rBody2D.velocity.y);
    }

    void PlayerMovement()
    {
        _playerInputX = Input.GetAxis("Horizontal");

        if(_playerInputX != 0)
        {
            _animator.SetBool("IsRunning", true);
        }
        if(_playerInputX == 0)
        {
            _animator.SetBool("IsRunning", false);
        }
        if(_playerInputX < 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        if(_playerInputX > 0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        /*_playerInputY = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(_playerInputX, _playerInputY) * _playerSpeed  * Time.deltaTime);*/
    }
    
    void Jump()
    {
        _rBody2D.AddForce(Vector2.up *_jumpForce, ForceMode2D.Impulse);
    }

    public void SignalTest()
    {
        Debug.Log("Señal recibida");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 7)
        {
            SoundManager.instance.GameOver();
            //soundManager.StopBGM();
            gameManager.GameOver();
        } 
    }
}



