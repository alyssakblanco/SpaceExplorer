using UnityEngine;
using System.Collections;

public class StartTransition : MonoBehaviour {
	
	public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Initiate.Fade("SunFact", Color.white, 1f);
        }  
    }
}
