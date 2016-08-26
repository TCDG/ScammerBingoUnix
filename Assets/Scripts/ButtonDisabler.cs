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
    Color defaultColor;
    void Awake()
    {
        defaultColor = buttons[0].image.color;
    }

    void Start()
    {
        scoreUI = scoreUI.GetComponent<Text>();
        defaultColor = buttons[0].image.color;
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = "Score: " + score.ToString();
        
    }

    public void BtnOnClick(int id)
    {
        if (buttons[id].enabled == true)
        {
            buttons[id].enabled = false;
            buttons[id].image.color = Color.gray;
            print("Button " + id + " clicked!");
            score++;
        } else
        {
            buttons[id].enabled = true;
            buttons[id].image.color = defaultColor;
            print("Button " + id + " reset!");
            score--;
        }
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
