using UnityEngine;
using System.Collections;

public class EndScreenHandler : MonoBehaviour
{
    public static string XMLFileName = "";

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUI.TextArea(new Rect(500, 100, 500, 100), "Thank you for playing!\n\nA Myo rhythm game by Douglass Chen and Nathan Wangsa", 200);
        //GUI.TextArea(new Rect(500, 300, 500, 100), "Thank you for playing!\n\nA Myo rhythm game by Douglass Chen and Nathan Wangsa", 200);
        XMLFileName = GUI.TextField(new Rect(500, 500, 300, 50), XMLFileName);
        if (GUI.Button(new Rect(500, 300, 200, 100), "Play Again?"))
        {
            Application.LoadLevel("Box On A Stick");
        }
    }
}
