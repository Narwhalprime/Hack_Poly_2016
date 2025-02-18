﻿using UnityEngine;
using System.Collections;

using Pose = Thalmic.Myo.Pose;

public class WandShoot : MonoBehaviour 
{


    /*
    public Rigidbody m_Bolt;
    public Rigidbody m_Ultimate;
    public Transform m_FireTransform;
    public Transform m_UltimateTransform;
    public AudioSource m_BoltAudio;
    public AudioClip m_FireClip;
    public AudioClip m_UltClip;

    private float accel;
    private float startTimer;
    private float ultTimer;
    private float fire_rate;

    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myo = null;

    void Start()
    {
        startTimer = Time.time;
        fire_rate = 0.5f;
    }

	// Update is called once per frame
	void Update () 
    {
        // Access the ThalmicMyo component attached to the Myo object.
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();
        accel = thalmicMyo.accelerometer.magnitude;
        //Debug.Log("Acceleration is " + accel);
        if (accel >= 3.5f && (Time.time-startTimer) > fire_rate)
        {
            //Fire Button is pressed
            Fire();
            Debug.Log("Fireball launched");
            startTimer = Time.time;
        }
        if ((Time.time - ultTimer) > 10 && thalmicMyo.pose == Pose.Fist)
        {
            UltimateFire();
            ultTimer = Time.time;
        }
	}

    private void Fire()
    {
        //Instantiate and launch shell
        Rigidbody boltInstance1 = Instantiate(m_Bolt) as Rigidbody;
        Rigidbody boltInstance2 = Instantiate(m_Bolt) as Rigidbody;
        Rigidbody boltInstance3 = Instantiate(m_Bolt) as Rigidbody;
        m_BoltAudio.clip = m_FireClip;
        m_BoltAudio.Play();
        
    }

    private void UltimateFire()
    {
        Rigidbody ult = Instantiate(m_Ultimate, m_UltimateTransform.position, m_UltimateTransform.rotation) as Rigidbody;
        m_BoltAudio.clip = m_UltClip;
        m_BoltAudio.Play();
    }
     */
}
