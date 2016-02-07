using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour 
{
    public Slider m_healthBar;

	// Use this for initialization
	void Start () 
    {
        m_healthBar.value = 75;
	}
	
	// Update is called once per frame
	void Update () 
    {
        m_healthBar.value = Instruction.health;
	}
}
