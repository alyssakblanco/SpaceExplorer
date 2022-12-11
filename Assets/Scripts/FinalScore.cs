using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI score;
    
    // Start is called before the first frame update
    void Start()
    {
        score.text = Globals.distanceFromSun.ToString() + " miles";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Initiate.Fade("NewGameScene", Color.white, 1f);
        }
        if (Input.GetKeyDown("space"))
        {
            Initiate.Fade("SunFact", Color.white, 1f);
        }
    }
}
