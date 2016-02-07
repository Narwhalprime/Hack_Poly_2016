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
    private float musicStartDelay;
    private float firstNoteDelay;
    private int numTicks;
    private const int NUM_PATHS = 3;

    private bool musicStarted;

    Vector3[] startVectors;

    private List<Object> enemies;
    
    // Not used yet, but will be needed for correct timing
    private float enemyTravelTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        interval = (60000 / 123) * 2;
        musicStartDelay = 2000; // two seconds before any music or notes begin
        firstNoteDelay = 2200;

        numTicks = 0;

        musicStarted = false;

        Vector3 playerPos = player.gameObject.transform.position;

        startVectors = new Vector3[NUM_PATHS] {new Vector3(-13, -1, 50) + playerPos, new Vector3(0, -1, 50) + playerPos,
            new Vector3(13, -1, 50) + playerPos};

        enemies = new List<Object>();
	}
	
	// Update is called once per frame
	void Update () {

        gameTime = (Time.time - startTime) * 1000;

        // is music supposed to be playing yet?
        if(!musicStarted && gameTime > musicStartDelay)
        {
            AudioSource.PlayClipAtPoint(song, player.transform.position);
            musicStarted = true;
        }

        // when is time to spawn another enemy?
        if (gameTime > (numTicks * interval) + firstNoteDelay + musicStartDelay - (EnemySphereMovement.ENEMY_TRAVEL_TIME * 1000))
        {
            InstantiateEnemy();
            ++numTicks;
            //Debug.Log("We have instantiated an enemy at time "+gameTime);
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
