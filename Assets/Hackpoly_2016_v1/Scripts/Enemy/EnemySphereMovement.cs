using UnityEngine;
using System.Collections;

public class EnemySphereMovement : MonoBehaviour {

    // relevant reference for interpolation:
    // http://docs.unity3d.com/ScriptReference/Vector3.Lerp.html

    Transform sphere;
    Transform player;               // Reference to the player's position.

    public string playerBodyName;
    private float lerpDistance;
    private float lerpTime;
    private float startTime;

    public static readonly float SPEED_FACTOR = 1.5F;

    float speed;

	// Use this for initialization
	void Start () {
        sphere = gameObject.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lerpDistance = Vector3.Distance(sphere.position, player.position);
        startTime = Time.time;
        // speed = SPEED_FACTOR * Time.deltaTime;
	}
	
	// Update is called once per frame
    void Update()
    {
        float dist = (Time.time - startTime) * SPEED_FACTOR;
        sphere.position = Vector3.Lerp(sphere.position, player.position, dist/lerpDistance);
    }

    // On collision with player, self-destroy
    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("Collision happened with " + col.gameObject.name);
        if (col.gameObject.name == playerBodyName || col.gameObject.name == "FireBall")
        {
            Destroy(gameObject);
        }
    }
}
