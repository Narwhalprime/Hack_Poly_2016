using UnityEngine;
using System.Collections;
using System.Xml;
using System;
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
    private const int NUM_PATHS = 4;

    private bool musicStarted;

    public string levelFileName = "song-survivalgame";

    Vector3[] startVectors;

    int[] beatmapNotes;
    
    private XmlDocument beatmapXML;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        musicStartDelay = 2000; // two seconds before any music or notes begin

        numTicks = 0;

        musicStarted = false;

        Vector3 playerPos = player.gameObject.transform.position;

        startVectors = new Vector3[NUM_PATHS] {new Vector3(-25, -1, 50) + playerPos, new Vector3(-8, -1, 50) + playerPos,
            new Vector3(8, -1, 50) + playerPos, new Vector3 (25, -1, 50) + playerPos};

        // Parsing XML file that has beatmap info
        TextAsset file = (TextAsset)Resources.Load(levelFileName, typeof(TextAsset));
        beatmapXML = new XmlDocument();
        beatmapXML.LoadXml(file.text);
        ParseBeatmap();
	}

    void ParseBeatmap()
    {
        XmlNodeList atts = beatmapXML.GetElementsByTagName("song")[0].ChildNodes;
        string beatmapTitle;
        int bpm = 60;
        float start = 0.0f;
        string notes = "";
        foreach (XmlNode att in atts)
        {   
            switch (att.Name)
            {
                case "title":
                    name = att.InnerText;
                    break;
                case "bpm":
                    bpm = int.Parse(att.InnerText);
                    break;
                case "start":
                    start = float.Parse(att.InnerText);
                    break;
                case "notes":
                    notes = att.InnerText;
                    break;
                default:
                    Debug.Log("Found bad XML tag! " + att.Name);
                    break;
            }
        }

        Char[] delims = new Char[] { };
        string[] tokens = notes.Split(delims, StringSplitOptions.RemoveEmptyEntries);
        beatmapNotes = new int[tokens.Length];
        for(int ind = 0; ind < tokens.Length; ind++)
        {
            Debug.Log("Token is: " + tokens[ind]);
            beatmapNotes[ind] = int.Parse(tokens[ind]);
        }

        interval = (60000 / bpm);
        firstNoteDelay = start;

        Debug.Log("interval, bpm = " + interval + " " + bpm);
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
        if (numTicks < beatmapNotes.Length)
        {
            int spawnPointInd = beatmapNotes[numTicks];
            if (spawnPointInd >= 0)
            {
                Vector3 startPos = startVectors[spawnPointInd];
                UnityEngine.Object enemyClone = Instantiate(enemy, startPos, transform.rotation);
            }
        }
    }
}
