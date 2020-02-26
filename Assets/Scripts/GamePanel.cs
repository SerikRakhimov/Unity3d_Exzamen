using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    private Transform root;

    [SerializeField]
    private Text lifesText;

    [SerializeField]
    private Text pointsText;

    [SerializeField]
    private Text ammoText;

    [SerializeField]
    private Text infoText;

    [SerializeField]
    private Text gameOverText;

    public void SetLifes(int lifes)
    {
        lifesText.text = "Жизни: " + lifes.ToString();
    }

    public void SetPoints(int points)
    {
        pointsText.text = "Очки: " + points.ToString();
    }

    public void SetAmmo(int ammoAll, int ammoGun)
    {
        ammoText.text = "Патронов: " + ammoAll.ToString() + ", из них в стволе: " + ammoGun.ToString();
    }

    public void SetInfo(string info)
    {
        infoText.text = info;
    }

    public void NoAmmo()
    {
        ammoText.text = "Патронов нет! Выстрел невозможен!";
    }

    public void GameOverTextSetEnabled(bool value)
    {
	    gameOverText.enabled = value;
    }

}
