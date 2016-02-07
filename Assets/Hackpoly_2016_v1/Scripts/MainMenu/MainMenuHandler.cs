using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class MainMenuHandler : MonoBehaviour {

    public static string XMLFileName = "";
    public string directoryPath;
    private List<string> fileNames;
    private string[] fileNamesArr;
    private int indSelected = 0;

	// Use this for initialization
    // File discovery reference:
    // http://www.41post.com/5069/programming/unity-list-files-in-a-directory
	void Start () {
        directoryPath = Application.dataPath + "/Resources";
  
        try  
        {  
            //Get the path of all files inside the directory and save them on a List  
            fileNames = new List<string>(Directory.GetFiles(directoryPath));  

            //For each string in the fileNames List   
            for (int i = fileNames.Count - 1; i >= 0; --i)  
            {
                string tempFileName = Path.GetFileName(this.fileNames[i]);
                //Remove the file path, leaving only the file name and extension
                //if(!Regex.IsMatch(tempFileName, pattern, RegexOptions.IgnoreCase))\
                
                if(Regex.IsMatch(tempFileName, ".*(\\.)xml$", RegexOptions.IgnoreCase))
                {
                    tempFileName = tempFileName.Substring(0, tempFileName.LastIndexOf('.'));
                    fileNames[i] = tempFileName;
                }
                else
                {
                    fileNames.RemoveAt(i);
                }
            }
            fileNamesArr = fileNames.ToArray();
        }
        //Catch any of the following exceptions and store the error message at the outputMessage string  
        catch (System.UnauthorizedAccessException UAEx)
        {
            Debug.Log("ERROR: " + UAEx.Message);
        }
        catch (System.IO.PathTooLongException PathEx)
        {
            Debug.Log("ERROR: " + PathEx.Message);
        }
        catch (System.IO.DirectoryNotFoundException DirNfEx)
        {
            Debug.Log("ERROR: " + DirNfEx.Message);
        }
        catch (System.ArgumentException aEX)
        {
            Debug.Log("ERROR: " + aEX.Message);
        }  
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnGUI()
    {
        GUI.TextArea(new Rect(500, 100, 500, 100), "Welcome to Casticks\nA Myo rhythm game by Douglass Chen and Nathan Wangsa", 200);

        indSelected = GUI.SelectionGrid(new Rect(500, 500, 600, 100), indSelected, fileNamesArr, 3);

        if (GUI.Button(new Rect(500, 300, 200, 100), "Start Game"))
        {
            XMLFileName = fileNamesArr[indSelected];
            Application.LoadLevel("Box On A Stick");
        }
    }
}
