using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int _health;
    public int _numberOfHearts;
    public Health[] _hearts;
    MenuManagement _menuManager;

    // Start is called before the first frame update
    void Start()
    {
        _menuManager = GameObject.Find("MenuManager").GetComponent<MenuManagement>();  
        _health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < _hearts.Length; i++)
        {
            if(_health > _numberOfHearts)
            {
                _health = _numberOfHearts;
            }
            if(_health < _numberOfHearts)
            {
                _numberOfHearts = _health;
            }

            if(i < _numberOfHearts)
            {
                _hearts[i].enabled = true;
            }
            
            else
            {
                _hearts[i].enabled = false;
            }
        }

        if(_health == 0)
        {
            _menuManager.Defeat();
        }
    }
}
