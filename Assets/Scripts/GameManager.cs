using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver){
            return;
        }
        if(PlayerStatus.Lives <= 0){
            EndGame();
        }
    }
    void EndGame(){
        isGameOver = true;
        gameOverUI.SetActive(true);
    }
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
