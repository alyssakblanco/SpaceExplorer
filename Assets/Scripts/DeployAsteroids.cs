using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployAsteroids : MonoBehaviour
{

    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    public GameObject powerup;

    private GameObject fallingObject;
    private float respawnTime = 0.6f;
    private int x;
    private int y;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(asteroidWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnAsteroid(){
        if(x == 0){
            fallingObject = asteroid1;
        }
        if(x == 1){
            fallingObject = asteroid2;
        }
        if(x == 2){
            fallingObject = asteroid3;
        }
        if(x == 3){
            fallingObject = powerup;
        }
        GameObject a = Instantiate(fallingObject) as GameObject;
        a.transform.position = new Vector3(Random.Range(-7, 8), 7, -1);
    }

    IEnumerator asteroidWave(){
        while(true){
            x = Random.Range(0, 3);
            y = Random.Range(0, 20);
            if ( Globals.lives < 3 && y == 5 ){
                x = 3;
            }
            yield return new WaitForSeconds(respawnTime);
            spawnAsteroid();
        } 
    }
}
