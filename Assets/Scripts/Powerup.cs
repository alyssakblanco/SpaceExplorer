using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float speed = 3.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private float deactivate_timer = 5f;
    private float rotateSpeed;
    private GameObject e;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, -speed, 0);
        Invoke("DeactivateGameObject", deactivate_timer);
        rotateSpeed = Random.Range(-0.7f, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, rotateSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other){
        Destroy(this.gameObject);
    }

    void DeactivateGameObject(){
        Destroy(this.gameObject);
    }

}