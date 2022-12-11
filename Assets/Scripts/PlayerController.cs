using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource soundEffect;
    public GameObject explosion;

    [SerializeField]
    private GameObject player_bullet;

    [SerializeField]
    private Transform bullet_spawn;

    private float speed = 10;
    Vector3 m_MyPosition;

    private bool isShipFlashing = false;

    void Update()
    {
        Attack();

        if(7.3f > gameObject.transform.position.x && gameObject.transform.position.x > -7.1){
            if (Input.GetKey("w"))
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            if (Input.GetKey("a"))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKey("s"))
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            if (Input.GetKey("d"))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            } 
        }
        if(7.3f < gameObject.transform.position.x){
            m_MyPosition.Set(7.29f, transform.position.y, transform.position.z);
            transform.position = m_MyPosition;
        }
        if(-7.1 > gameObject.transform.position.x){
            m_MyPosition.Set(-7.09f, transform.position.y, transform.position.z);
            transform.position = m_MyPosition;
        }
        if(-4.3f > gameObject.transform.position.y){
            m_MyPosition.Set(transform.position.x, -4.2f, transform.position.z);
            transform.position = m_MyPosition;
        }
        if(4f < gameObject.transform.position.y){
            m_MyPosition.Set(transform.position.x, 3.9f, transform.position.z);
            transform.position = m_MyPosition;
        }
    }

    void Attack(){
        if(Input.GetKeyDown("space")){
            var bullet = Instantiate(player_bullet, bullet_spawn.position, Quaternion.identity);
            bullet.transform.Rotate(0, 0, 136);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Asteroid") ){
            if(Globals.lives >= 1){
                Globals.lives--;
                isShipFlashing = true;
                StartCoroutine(flashShip());
            }
            if(Globals.lives == 0){
                Destroy(this.gameObject);
                GameObject e = Instantiate(explosion) as GameObject;
                e.transform.position = transform.position;
                Destroy(e, 0.5f);
                Initiate.Fade("GameOverScene", Color.white, 0.5f);
            }
        }
        if (other.gameObject.CompareTag("Powerup") ){
            soundEffect.Play();
            Globals.lives += 1;
        }
    }

    IEnumerator flashShip(){
        while(isShipFlashing){
            yield return new WaitForSeconds(0.1f);
            gameObject.GetComponent<Renderer>().enabled= false;
            yield return new WaitForSeconds(0.1f);
            gameObject.GetComponent<Renderer>().enabled= true;
            yield return new WaitForSeconds(0.1f);
            gameObject.GetComponent<Renderer>().enabled= false;
            yield return new WaitForSeconds(0.1f);
            gameObject.GetComponent<Renderer>().enabled= true;
            isShipFlashing = false;
        } 
    }
}   
