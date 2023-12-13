using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int pelaajanPisteet;
    public Text pisteTeksti;
    public GameObject gameOverScreen;
    public bool isAlive = true;

    [ContextMenu("Lis‰‰ pisteet")]
    public void addScore(int scoreToAdd)
    {
        
        pelaajanPisteet = pelaajanPisteet + scoreToAdd;
        pisteTeksti.text = pelaajanPisteet.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

}
