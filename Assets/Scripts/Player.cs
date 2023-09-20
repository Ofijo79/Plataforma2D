using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]float _playerSpeed = 5;
    float _playerInputX;
    //float _playerInputY;
    [SerializeField]float _jumpForce = 5;
    

    Rigidbody2D _rBody2D;

    GroundSensor _sensor;

    
    // Start is called before the first frame update
    void Start()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
        _sensor = GetComponentInChildren<GroundSensor>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if(Input.GetButtonDown("Jump") && _sensor._isGrounded)
        {
            Jump();
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
        /*_playerInputY = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(_playerInputX, _playerInputY) * _playerSpeed  * Time.deltaTime);*/
    }
    
    void Jump()
    {
        _rBody2D.AddForce(Vector2.up *_jumpForce, ForceMode2D.Impulse);
    }
}

