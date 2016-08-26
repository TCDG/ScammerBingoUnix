using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class GetOS : MonoBehaviour {

    public Text title; 

	// Use this for initialization
	void Start () {
	    if (Application.platform == RuntimePlatform.LinuxPlayer)
        {
            title.text = "Scammer Bingo: Linux Edition";
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            title.text = "Scammer Bingo: Android Edition";
        }
        if (Application.platform == RuntimePlatform.OSXPlayer)
        {
            title.text = "Scammer Bingo: OSX Edition";
        }
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
        {
            title.text = "Scammer Bingo: In Editor";
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
