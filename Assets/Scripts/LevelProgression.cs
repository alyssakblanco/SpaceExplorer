using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgression : MonoBehaviour
{
    public int currentLevel;
    public string nextScene;

    private float time = 0.0f;
    private float interpolationPeriod = 0.1f;
    // https://www.qrg.northwestern.edu/projects/vss/docs/space-environment/3-orbital-lengths-distances.html
    private double[] distances = {36800000, 67200000, 93000000, 141600000, 483600000, 886500000, 1783700000, 2795200000, 3670100000};
    private double scoreUpdate;

    // Start is called before the first frame update
    void Start()
    {
        Globals.distanceFromSun = distances[currentLevel];
        Globals.distanceToPlanet = distances[currentLevel + 1] - distances[currentLevel];

        scoreUpdate = Globals.distanceToPlanet / 100;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (Globals.distanceToPlanet <= 0){
            Initiate.Fade(nextScene, Color.white, 0.5f);
        }else{
            if (time >= interpolationPeriod) {
                time = 0.0f;
        
                Globals.distanceFromSun += 100000;
                Globals.distanceToPlanet -= 100000;
            }
        } 
    }
}