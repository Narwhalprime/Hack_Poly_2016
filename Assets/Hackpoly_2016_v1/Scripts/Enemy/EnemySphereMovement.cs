using UnityEngine;
using System.Collections;

public class EnemySphereMovement : MonoBehaviour {

    // relevant reference for interpolation:
    // http://docs.unity3d.com/ScriptReference/Vector3.Lerp.html

    Transform sphere;
    Vector3 sphereStartPos;
    Transform target;               // Reference to the player's position.
    
    public Material[] colors = new Material[4];
    public Material mat0;
    public Material mat1;
    public Material mat2;
    public Material mat3;

    public string playerBodyName;
    public string shieldName;
    private float lerpDistance;
    private float lerpTime;
    private float startTime;
    private float duration;

    // public static readonly float SPEED_FACTOR = 1.5F;
    public static readonly float ENEMY_TRAVEL_TIME = 4.0F;

    float speed;

	// Use this for initialization
	void Start () 
    {
        colors[0] = mat0;
        colors[1] = mat1;
        colors[2] = mat2;
        colors[3] = mat3;
        GetComponent<Renderer>().material = colors[SpawnEnemy.colRot % 4];
        sphere = gameObject.transform;
        sphereStartPos = sphere.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        startTime = Time.time;
        duration = ENEMY_TRAVEL_TIME;
	}
	
	// Update is called once per frame
    void Update()
    {
        sphere.position = Vector3.Lerp(sphereStartPos, target.position + new Vector3(0, 4.5f, 0), (Time.time - startTime) / duration);
    }

    // On collision with player, self-destroy
    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("Collision happened with " + col.gameObject.name);
        if (col.gameObject.name == playerBodyName)
        {
            Debug.Log("Combo lost");
            Instruction.combo = 0;
            Instruction.health -= 10;
        }
        else if (col.gameObject.name == shieldName)
        {
            Instruction.combo++;
            if(Instruction.health < 95)
            {
                Instruction.health += 5;
            }
            else
            {
                Instruction.health += 100 - Instruction.health;
            }
            
        }
        Destroy(gameObject);
    }
}