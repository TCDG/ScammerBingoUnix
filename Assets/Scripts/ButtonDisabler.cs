using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class ButtonDisabler : MonoBehaviour
{
    public Button[] buttons = new Button[16];
    int score = 0;
    // Use this for initialization
    public Text scoreUI;
    
    void Start()
    {
        scoreUI = scoreUI.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = "Score: " + score.ToString();
        
    }

    public void BtnOnClick(int id)
    {
        buttons[id].enabled = false;
        buttons[id].interactable = false;
        buttons[id].image.color = Color.gray;
        print("Button " + id + " clicked!");
        score++;
    }

    public void Reset()
    {
        /**
        bool resetDone = false;
        int i = 0;
        while (!resetDone)
        {
            buttons[i].enabled = true;
            buttons[i].interactable = true;
            i++;
            if(i > 16)
            {
                resetDone = true;
            }

        }*/
        Application.LoadLevel(0);
    }
}
