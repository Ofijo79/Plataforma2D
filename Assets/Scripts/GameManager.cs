using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set;}

    public int vidas;
    public bool isGameOver;
    private int score;
    public Text scoreText;
    // Start is called before the first frame update
    void Awake()
    {
        score = 0;
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
        isGameOver = true;

        StartCoroutine("LoadScene");
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene(2);
    }

    public void AddStar()
    {
        score++;
        scoreText.text = "x" + score;
    }


}
