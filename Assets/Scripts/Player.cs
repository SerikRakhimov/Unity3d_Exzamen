using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GamePanel gamePanel;
    
    // начальное: кол-во жизней
    // начальное: кол-во очков
    [SerializeField]
    private int initLifes, initPoints;

    // кол-во жизней
    // кол-во очков
    private int lifes, points;

    private void Start()
    {
	// отключить текст "Game Over!"
	gamePanel.GameOverTextSetEnabled(false);

        // кол-во жизней
	lifes = initLifes;
        // вывести кол-во жизней
	gamePanel.SetLifes(lifes);

        // кол-во очков
	points = initPoints;
        // вывести кол-во очков
	gamePanel.SetPoints(points);
    }

    // добавление очков
    public void AddPoints(int value)
    {
	points = points + value;
        // вывести кол-во очков
	gamePanel.SetPoints(points);
    }    

    // при обнаружении мины -1
    public void TakeAwayLifes(int lifesTakeAway)
    {
	lifes = lifes - lifesTakeAway;

	if (lifes < 0)
	{
		lifes = 0;
	}

	gamePanel.SetLifes(lifes);

	// если кол-во "жизней" = 0
	if (lifes == 0)
	{	
		// вывести текст "Game Over!"
		gamePanel.GameOverTextSetEnabled(true);
		Time.timeScale = 0;
		Application.Quit();
	}
    }
   
}
