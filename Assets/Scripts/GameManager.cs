using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set;}

    public int vidas;
    public Canvas UI;
    // Start is called before the first frame update
    void Awake()
    {
        UI = GetComponent<Canvas>();
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}
