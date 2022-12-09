using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float speed = 5f;
    private float deactivate_timer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivateGameObject", deactivate_timer);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 tmp = transform.position;
        tmp.y += speed * Time.deltaTime;
        transform.position = tmp;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Asteroid") ){
            Destroy(this.gameObject);
        }
    }

    void DeactivateGameObject(){
        Destroy(this.gameObject);
    }
}
