using UnityEngine;
using System.Collections;

using Pose = Thalmic.Myo.Pose;

public class WandShoot : MonoBehaviour 
{
    public Rigidbody m_Bolt;
    public Rigidbody m_Ultimate;
    public Transform m_FireTransform;
    public Transform m_UltimateTransform;
    public AudioSource m_BoltAudio;
    public AudioClip m_FireClip;
    public AudioClip m_UltClip;

    private float accel;
    private int timer;
    private bool super;

    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myo = null;

    void Start()
    {
        timer = 0;
        super = false;
    }

	// Update is called once per frame
	void Update () 
    {
        // Access the ThalmicMyo component attached to the Myo object.
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();
        accel = thalmicMyo.accelerometer.magnitude;
        //Debug.Log("Acceleration is " + accel);
        if (accel >= 3.5f)
        {
            //Fire Button is pressed
            Fire();
        }
        if (super && thalmicMyo.pose == Pose.Fist)
        {
            UltimateFire();
        }
        if(timer == 500)
        {
            Debug.Log("Ultimate is Ready");
            super = true;
        }
        timer++;
	}

    private void Fire()
    {
        //Instantiate and launch shell
        Rigidbody boltInstance = Instantiate(m_Bolt, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        boltInstance.velocity = 30 * m_FireTransform.forward;
        m_BoltAudio.clip = m_FireClip;
        m_BoltAudio.Play();
        
    }

    private void UltimateFire()
    {
        Rigidbody ult = Instantiate(m_Ultimate, m_UltimateTransform.position, m_UltimateTransform.rotation) as Rigidbody;
        m_BoltAudio.clip = m_UltClip;
        m_BoltAudio.Play();
        super = false;
    }
}
