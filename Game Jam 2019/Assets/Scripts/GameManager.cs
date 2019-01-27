using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int winAmount = 10000000; //10 million
    public int startAmount = 50000;
    public int currentAmount;

    public Transform winScreen;
    public Transform loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        currentAmount = startAmount;
    }

    // Update is called once per frame
    void Update()
    {
        //  WIN CONDITION
        if(currentAmount >= winAmount)
        {
            Time.timeScale = 0;
            // set win UI
            winScreen.gameObject.SetActive(true);
        }

        //  LOSE CONDITION
        if(currentAmount <= 0)
        {
            Time.timeScale = 0;
            // set lose UI
            loseScreen.gameObject.SetActive(true);
        }
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void increment(int cash)
    {
        currentAmount += cash;
    }

    public void decrement(int cash)
    {
        currentAmount -= cash;
    }
}
