using UnityEngine;
using System.Collections;

public class MainMenuHandler : MonoBehaviour {

    public static string XMLFileName = "";

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.TextArea(new Rect(500, 100, 500, 100), "Welcome to Casticks\nA Myo rhythm game by Douglass Chen and Nathan Wangsa", 200);
        XMLFileName = GUI.TextField(new Rect(500, 500, 300, 50), XMLFileName);
        if (GUI.Button(new Rect(500, 300, 200, 100), "Start Game"))
        {
            Application.LoadLevel("Box On A Stick");
        }
    }
}
