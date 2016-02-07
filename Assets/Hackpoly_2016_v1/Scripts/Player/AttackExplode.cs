using UnityEngine;
using System.Collections;

public class AttackExplode : MonoBehaviour 
{
    
	// Use this for initialization
	void Start () 
    {
        
	}
    
    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Out of Bounds");
        }
    }
	
	// Update is called once per frame
	public void OnTriggerEnter(Collider other)
    {
        if(other.name != "Camera" || other.name != "Big Bang")
        {
            Destroy(gameObject);
            Debug.Log(gameObject + " collided with " + other.name);
        }
    }
}
