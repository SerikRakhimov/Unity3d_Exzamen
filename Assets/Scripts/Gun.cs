using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // эффект выстрела
    [SerializeField]
    private Player player;

    // начальное: общеее кол-во патронов
    // начальное: из них в стволе оружия
    [SerializeField]
    private int initAmmoAll, countAmmoHolder;
    // уроны, дальность, скорострельность

    [SerializeField]
    private float damage, rangeGun, rangeBandolier, ShootSpeed;
    
    // эффект выстрела
    [SerializeField]
    private ParticleSystem shootEffect;

    // звук
    [SerializeField]
    private AudioSource audioSource;

    // перехарядка
    // дальность
    // скорострельность
    // эффект попадания
    [SerializeField]
    private GameObject hitEffect;
 
    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private GamePanel gamePanel;

    // общеее кол-во патронов
    // из них в стволе оружия
    private int currentAmmoAll, currentAmmoGun;

    private  void Start()
    {
        // общеее кол-во патронов
        currentAmmoAll = initAmmoAll;
        // из них в стволе оружия; присваивается 10 (countAmmoHolder)
        currentAmmoGun = countAmmoHolder;
        // вывести количество патронов
        gamePanel.SetAmmo(currentAmmoAll, currentAmmoGun);
     }

    private  void Update()
    {
    	Mark mark;
    	gamePanel.SetInfo("");

        if (currentAmmoAll != 0 && currentAmmoGun <= 0)
        {
            // перезарядка оружия
            // из них в стволе оружия; присваивается 10 (countAmmoHolder)
            currentAmmoGun = countAmmoHolder;
        }
	if (currentAmmoAll == 0 && currentAmmoGun == 0)
        {
	    gamePanel.NoAmmo();

        }
	else
	{
            // вывести количество патронов
	    gamePanel.SetAmmo(currentAmmoAll, currentAmmoGun);
	}

        // пускаем луч/ не выстрел
	RaycastHit hit;
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, rangeBandolier))
        {

	    switch (hit.transform.tag)
      	    {
		// смотрим на патроны
            	case "Bandolier":
			gamePanel.SetInfo("Патроны");
			// добавляем патронов
        		currentAmmoAll = currentAmmoAll + 10;
			// уничтожаем объект
		        Destroy(hit.transform.gameObject);
             	 	break;
            	case "Mine":
			gamePanel.SetInfo("Осторожно! Мина!");
			// отнимаем жизнь у игрока
        		player.TakeAwayLifes(1);
			// уничтожаем объект
		        Destroy(hit.transform.gameObject);
             	 	break;
            	case "Mark":
	                mark = hit.transform.GetComponent<Mark>();
			if (mark != null)
			{
				gamePanel.SetInfo("Мишень! " + mark.GetInfoLifes());
			}
             	 	break;
	    }
        }

        // нажата левая кнопка мыши
    	if(Input.GetButtonDown("Fire1"))
   	{
       		// выстрел
        	Shoot();
    	}
    }

    // функция выстрела
    private void Shoot()
    {

	Mark mark;
	// если патронов нет - return
        if (currentAmmoAll == 0 && currentAmmoGun ==0)
        {
            return;
        }

	// уменьшаем кол-во патронов на 1
        currentAmmoAll = currentAmmoAll - 1;
        currentAmmoGun = currentAmmoGun - 1;

        RaycastHit hit;
        // откуда луч выходит
        // в каком направлении
        // куда записать информацию о том, во что попал
        // дальность
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, rangeGun))
        {
            // эффект выстрелв
            shootEffect.Play();

            // эффект попадания
            // что создать
            // где создать
            //как повернуть
            GameObject effect = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(effect,1f);

	    switch (hit.transform.tag)
      	    {
		// выстрел проведен на патроны
            	case "Bandolier":
			// уничтожаем объект (без добавления новых патронов)
		        Destroy(hit.transform.gameObject);
             	 	break;

		// выстрел проведен на мишень
            	case "Mark":
			gamePanel.SetInfo("Мишень!");
			// получаем объект
	                mark = hit.transform.GetComponent<Mark>();
			if (mark != null)
			{
				// уменьшаем кол-во жизней мишени
				mark.TakeAwayMarkLifes(1);
				// если кол-во жизней нет
				if (mark.NoMarkLifes())
				{
					// добавление очков игроку
					player.AddPoints(1);
					// уничтожаем объект
		        		Destroy(hit.transform.gameObject);
				}
			}
             	 	break;
	    }
        }
    }

}
