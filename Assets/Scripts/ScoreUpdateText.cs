using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUpdateText : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = Globals.distanceFromSun.ToString() + " mi";
        timer.text = Globals.distanceToPlanet.ToString() + " mi";
    }
}
