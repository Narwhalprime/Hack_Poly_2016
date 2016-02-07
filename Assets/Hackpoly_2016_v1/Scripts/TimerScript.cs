using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TimerScript : MonoBehaviour {

	private float startTime;
	private String textTime;

	private float guiTime;

	private int minutes;
	private int seconds;
	private int fraction;

	Text textField;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
        textField = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		guiTime = Time.time - startTime;
		minutes = (int)(guiTime / 60);
		seconds = (int)(guiTime) % 60;
		fraction = (int)(guiTime * 100 ) % 100;

		textTime = String.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
		textField.text = textTime;
	}
}
