using UnityEngine;
using System.Collections;

public class ExpEnd : MonoBehaviour 
{
    private int timer;
	// Use this for initialization
	void Start () 
    {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(timer == 300)
        {
            Destroy(gameObject);
        }
        timer++;
	}
}
