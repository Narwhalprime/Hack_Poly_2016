using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour {

    public Rigidbody enemy;
    public GameObject player;
    public AudioClip song;

    private float startTime;
    private float gameTime; // number of milliseconds passed
    private float interval;
    private float startBuffer;
    private int numTicks;
    private const int NUM_PATHS = 3;

    Vector3[] startVectors;

    private List<Object> enemies;
    
    // Not used yet, but will be needed for correct timing
    private float enemyTravelTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        interval = 60000/123;
        startBuffer = 2000; // two seconds buffer
        numTicks = 0;

        Vector3 playerPos = player.gameObject.transform.position;

        startVectors = new Vector3[NUM_PATHS] {new Vector3(-13, -1, 15) + playerPos, new Vector3(0, -1, 15) + playerPos,
            new Vector3(13, -1, 15) + playerPos};

        enemies = new List<Object>();
        AudioSource.PlayClipAtPoint(song, player.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        gameTime = (Time.time - startTime) * 1000;
        if (gameTime > (numTicks * interval) + startBuffer)
        {
            InstantiateEnemy();
            ++numTicks;
            Debug.Log("We have instantiated an enemy at time "+gameTime);
        }
	}

    void InstantiateEnemy()
    {
        int randInt = (int)Random.Range(0, NUM_PATHS);
        Vector3 startPos = startVectors[randInt];

        Object enemyClone = Object.Instantiate(enemy, startPos, transform.rotation);
        enemies.Add(enemyClone);
    }
}
