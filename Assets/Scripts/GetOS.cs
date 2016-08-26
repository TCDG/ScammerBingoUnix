using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.Collections.Generic;
using System.IO;

public class GetOS : MonoBehaviour
{

    public Text title;


    void Start()
    {
        string platform = null;
        int id = 0;
        if (!Application.isEditor)
        {

            if (!File.Exists(Application.dataPath + "userid.txt"))
            {
                id = Random.Range(100000, 999999);
                File.WriteAllText(Application.dataPath + "userid.txt", id.ToString());
                Analytics.SetUserId(id.ToString());

            }
            else
            {
                id = int.Parse(File.ReadAllText(Application.dataPath + "userid.txt"));
            }

        }
        if (Application.platform == RuntimePlatform.LinuxPlayer)
        {
            title.text = "Scammer Bingo: Linux Edition";
            platform = "linux";
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            title.text = "Scammer Bingo: Android Edition";
            platform = "mac-osx";
        }
        if (Application.platform == RuntimePlatform.OSXPlayer)
        {
            title.text = "Scammer Bingo: OSX Edition";
            platform = "windows";
        }
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
        {
            title.text = "Scammer Bingo: In Editor";
            platform = "editor";
        }
        if (!Application.isEditor)
        {
            Process process = Process.GetCurrentProcess();
            Analytics.CustomEvent("UserPlatformVersion", new Dictionary<string, object>
            {
                { "potions", platform },
                { "userid", id },
                { "memoryused", process.PrivateMemorySize64 }
            });
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
