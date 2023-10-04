using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [Tooltip("Controla la velocidad de movimiento del PJ")]
    [SerializeField]float _playerSpeed = 5;
    float _playerInputX;
    //float _playerInputY;
    [Tooltip("Controla la fuerza de salto del PJ")]
    [SerializeField]float _jumpForce = 5;

    SpriteRenderer spriterenderer;
    

    Rigidbody2D _rBody2D;

    //GroundSensor _sensor;

    Animator _animator;

    
    // Start is called before the first frame update
    void Start()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
        //_sensor = GetComponentInChildren<GroundSensor>();
        _animator = GetComponentInChildren<Animator>();
        spriterenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if(Input.GetButtonDown("Jump") && GroundSensor._isGrounded)
        {
            Jump();
            _animator.SetBool("IsJumping", true);
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
            spriterenderer.flipX = true;
        }
        if(_playerInputX > 0)
        {
            spriterenderer.flipX = false;
        }
        /*_playerInputY = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(_playerInputX, _playerInputY) * _playerSpeed  * Time.deltaTime);*/
    }
    
    void Jump()
    {
        _rBody2D.AddForce(Vector2.up *_jumpForce, ForceMode2D.Impulse);
    }
}



