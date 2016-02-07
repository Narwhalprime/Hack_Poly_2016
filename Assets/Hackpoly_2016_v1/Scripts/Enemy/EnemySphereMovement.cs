using UnityEngine;
using System.Collections;

public class EnemySphereMovement : MonoBehaviour {

    // relevant reference for interpolation:
    // http://docs.unity3d.com/ScriptReference/Vector3.Lerp.html

    Transform sphere;
    Vector3 sphereStartPos;
    Transform target;               // Reference to the player's position.

    public string playerBodyName;
    private float lerpDistance;
    private float lerpTime;
    private float startTime;
    private float duration;

    // public static readonly float SPEED_FACTOR = 1.5F;
    public static readonly float ENEMY_TRAVEL_TIME = 4.0F;

    float speed;

	// Use this for initialization
	void Start () {
        sphere = gameObject.transform;
        sphereStartPos = sphere.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        startTime = Time.time;
        duration = ENEMY_TRAVEL_TIME;
	}
	
	// Update is called once per frame
    void Update()
    {
        sphere.position = Vector3.Lerp(sphereStartPos, target.position + new Vector3(0, 4, 0), (Time.time - startTime) / duration);
    }

    // On collision with player, self-destroy
    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("Collision happened with " + col.gameObject.name);
        if (col.gameObject.name == playerBodyName || col.gameObject.name == "FireBall")
        {
            Debug.Log("Collision happened with " + col.gameObject.name + " AT TIME " + Time.time);
            Destroy(gameObject);
        }
    }
}
