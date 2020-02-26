using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    // радиус круга, в котором создается случайная точка - координата
    [SerializeField]
    private float radius;

    // задержка в секундах, прежде чем объект будет удален
    [SerializeField]
    private float delayDestroySeconds;

    // средняя величина задержки в секундах
    [SerializeField]
    private float creatyDelaySecondsAVG;

    // prefab MarkBlack
    [SerializeField]
    private Transform prefabMarkBlack;

    // prefab MarkBlack высота
    [SerializeField]
    private float markBlackHeight;

    // prefab MarkRed
    [SerializeField]
    private Transform prefabMarkRed;

    // prefab MarkRed высота
    [SerializeField]
    private float markRedHeight;

    // prefab MarkGreen
    [SerializeField]
    private Transform prefabMarkGreen;

    // prefab MarkGreen высота
    [SerializeField]
    private float markGreenHeight;

    // prefab MarkMine
    [SerializeField]
    private Transform prefabMarkMine;

    // prefab MarkMine высота
    [SerializeField]
    private float markMineHeight;

    // макс.размеры Land (ширина, высота)
    private float maxLenLandX, maxLenLandZ;

    private float delaySeconds;

    private void Start()
    {
        // макс.размеры Land (ширина, высота)
	maxLenLandX = transform.localScale.x;
	maxLenLandZ = transform.localScale.z;
	
	// задержка перед созданием следующего префаба 
	SetDelaySeconds();
    }

    private void Update()
    {
        if (delaySeconds > 0)
        {
            delaySeconds = delaySeconds - Time.deltaTime;  // отнимаем время
            if (delaySeconds < 0)  // время задержки вышло
            {
		// Создание нового prefab
		CreatePrefab();

		// задержка перед созданием следующего префаба 
		SetDelaySeconds();

            }
        }
    }

  private void SetDelaySeconds()
    {
	// случайная величина задержки
	delaySeconds = Random.Range(0f, 2 * creatyDelaySecondsAVG);
    }

  private void CreatePrefab()
    {
	// получаем случайную точку внутри круга с радиусом = radius
	Vector3 offset = Random.insideUnitCircle * radius;

	// случайные числа в интервале
	float randX = Random.Range(radius, maxLenLandX - radius);
	float randZ = Random.Range(radius, maxLenLandZ - radius);

	// итого случайная координата для префаба
	Vector3 pos = new Vector3(randX, markBlackHeight, randZ) + new Vector3(offset.x, 0, offset.y);
	
	// получить случайное целое число от 1 до 4
	int iPrefab = Mathf.RoundToInt(Random.Range(0f, 3f) + 1);

	switch (iPrefab)
      	{
		// prefab MarkBlack
            	case 1:
			// создаем префаб в рассчитанных координатах
			var mb =  Instantiate(prefabMarkBlack, pos, Quaternion.identity);
       			// уничтожение созданного префаба через delayDestroySeconds секунд
			Destroy(mb.gameObject, delayDestroySeconds);
             	 	break;

		// prefab MarkRed
            	case 2:
			// создаем префаб в рассчитанных координатах
			var mr =  Instantiate(prefabMarkRed, pos, Quaternion.identity);
       			// уничтожение созданного префаба через delayDestroySeconds секунд
			Destroy(mr.gameObject, delayDestroySeconds);
             	 	break;

		// prefab MarkGreen
            	case 3:
			// создаем префаб в рассчитанных координатах
			var mg =  Instantiate(prefabMarkGreen, pos, Quaternion.identity);
       			// уничтожение созданного префаба через delayDestroySeconds секунд
			Destroy(mg.gameObject, delayDestroySeconds);
             	 	break;

		// prefab MarkMine
            	case 4:
			// создаем префаб в рассчитанных координатах
			var mm =  Instantiate(prefabMarkMine, pos, Quaternion.identity);
       			// уничтожение созданного префаба через delayDestroySeconds секунд
			Destroy(mm.gameObject, delayDestroySeconds);
             	 	break;
        }
    }

}
