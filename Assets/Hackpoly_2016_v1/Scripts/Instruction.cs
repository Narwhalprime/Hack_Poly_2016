using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Draw simple instructions for sample scene.
// Check to see if a Myo armband is paired.
public class Instruction: MonoBehaviour
{
    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myo = null;

    public static int combo = 0;
    public static int max_combo = 0;
    public static int health = 100;

    // Draw some basic instructions.
    void OnGUI()
    {
        GUI.skin.label.fontSize = 20;

        ThalmicHub hub = ThalmicHub.instance;

        // Access the ThalmicMyo script attached to the Myo object.
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

        if (!hub.hubInitialized)
        {
            GUI.Label(new Rect(12, 8, Screen.width, Screen.height),
                "Cannot contact Myo Connect. Is Myo Connect running?\n" +
                "Press Q to try again."
            );
        }
        else if (!thalmicMyo.isPaired)
        {
            GUI.Label(new Rect(12, 8, Screen.width, Screen.height),
                "No Myo currently paired."
            );
        }
        else if (!thalmicMyo.armSynced)
        {
            GUI.Label(new Rect(12, 8, Screen.width, Screen.height),
                "Perform the Sync Gesture."
            );
        }
        else if (health > 0)
        {
            GUI.Label(new Rect(12, 8, Screen.width, Screen.height),
                "Point hand to center of screen and open fingers\n" +
                "Block incoming blocks to the music" +
                "\nCombo: " + combo +
                "\nHealth: " + health
            );
            if (health <= 0)
            {
                new WaitForSeconds(2);
                Application.LoadLevel("End Screen");
            }
        }
    }

    void Update()
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (Input.GetKeyDown("q"))
        {
            hub.ResetHub();
        }
    }
}