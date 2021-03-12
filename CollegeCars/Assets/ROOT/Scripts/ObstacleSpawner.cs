using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public bool GameActive = true;
    public float CountdownTimer;
    public float CooldownTime = 1f;
    public GameObject ObstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        CountdownTimer = CooldownTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameActive == true)
        {
            CountdownTimer -= Time.deltaTime;
            if (CountdownTimer <= 0)
            {
                int Location = Random.Range(0, 5);
                GameObject spawnedcube = Instantiate(ObstaclePrefab, gameObject.transform.GetChild(Location));
                spawnedcube.transform.parent = null;

                CountdownTimer = CooldownTime;
            }
        }
    }

}
