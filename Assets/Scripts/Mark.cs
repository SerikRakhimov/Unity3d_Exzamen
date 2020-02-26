using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark : MonoBehaviour
{
    // кол-во жизней у мишени (начальное)
    [SerializeField]
    private int initMarkLifes;

    // кол-во жизней у мишени (текущее)
    private int markLifes;

    private void Start()
    {
	markLifes = initMarkLifes;
    }

    // при попадании в мишень 
    public void TakeAwayMarkLifes(int lifesTakeAway)
    {
	markLifes = markLifes - lifesTakeAway;
    }

    // при попадании в мишень 
    public bool NoMarkLifes()
    {
	return (markLifes <= 0);
    }

    // Информация о кол-ве жизней 
    public string GetInfoLifes()
    {
	return "Жизни: " + markLifes + "/" + initMarkLifes;
    }

}
