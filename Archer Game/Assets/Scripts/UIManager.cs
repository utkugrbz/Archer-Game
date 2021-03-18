using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIManager : MonoBehaviour
{

    public static UIManager Instance;
    
    public Image[] player1Hearts;
    public Image[] player2Hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Text playerWinText;
    public GameObject gameOverPanel;


    private void Awake()
    {
        Instance = this;

    }
    public void OnPlayerDamage(Archer archer)
    {
        if(archer.playerType == Global.PlayerType.Player1)
        {
            for (int i = 0; i < player1Hearts.Length; i++) 
            {
                if (archer.hp > i)
                    player1Hearts[i].sprite = fullHeart;
                else
                    player1Hearts[i].sprite = emptyHeart;

            }
            if(archer.hp <= 0)
            {
                playerWinText.text = ("PLAYER 2 WIN");
                playerWinText.color = Color.red;
                gameOverPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else
        {
            for (int i = 0; i < player2Hearts.Length; i++)
            {
                if (archer.hp > i)
                    player2Hearts[i].sprite = fullHeart;
                else
                    player2Hearts[i].sprite = emptyHeart;

            }
            if (archer.hp <= 0)
            {
                playerWinText.text = ("PLAYER 1 WIN");
                playerWinText.color = Color.green;
                gameOverPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}


