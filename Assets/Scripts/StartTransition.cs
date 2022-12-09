using UnityEngine;
using System.Collections;

public class TransitionScript : MonoBehaviour {
	
	public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Initiate.Fade("SunFact", Color.white, 0.5f);
        }
        
    }
}
