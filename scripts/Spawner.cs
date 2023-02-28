using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle1;
    public float decreaseTime;
    public float minTime = 0.65f;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (timeBtwSpawn <= 0)
        {
            transform.position += new Vector3(0, 0, 22);
            Instantiate(obstacle1, transform.position, Quaternion.identity);
            transform.position += new Vector3(0, 0, 22);

            timeBtwSpawn = startTimeBtwSpawn;
            if(startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
