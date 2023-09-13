using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]float _playerSpeed = 5;
    float _playerInputX;
    float _playerInputY;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        _playerInputX = Input.GetAxis("Horizontal");
        _playerInputY = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(_playerInputX, _playerInputY) * _playerSpeed  * Time.deltaTime);
    }
    
}
