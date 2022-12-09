using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetLaunchMovement : MonoBehaviour
{
    public float speed;

    void Update()
    {
        if(gameObject.transform.position.y > -15 ){
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        
    }

    // IEnumerator waiter()
    // {
    //     //Wait for 4 seconds
    //     yield return new WaitForSeconds(4);

    //     //Rotate 90 deg
    //     transform.position = new Vector3(0.18,-15,3) * Time.deltaTime; 
    // }
}
