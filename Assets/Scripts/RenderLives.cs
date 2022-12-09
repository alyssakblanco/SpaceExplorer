using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderLives : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    // Update is called once per frame
    void Update()
    {
        if(Globals.lives == 3){
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            star3.gameObject.SetActive(true);
        }
        if(Globals.lives == 2){
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            star3.gameObject.SetActive(false);
        }
        if(Globals.lives == 1){
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(false);
            star3.gameObject.SetActive(false);
        }
        if(Globals.lives == 0){
            Initiate.Fade("GameOverScene", Color.white, 0.5f);
        }
    }
}
