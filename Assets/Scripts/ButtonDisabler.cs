using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.IO;

public class ButtonDisabler : MonoBehaviour
{
    public Button[] buttons = new Button[16];
    public Text[] buttonText = new Text[16];
    public ButtonTextHolder buttonTextHolder;
    int score = 0;
    // Use this for initialization
    public Text scoreUi;
    bool finishedNames = false;
    Color defaultColor;
    public int i = 0;
    void Awake()
    {
        defaultColor = buttons[0].image.color;
    }

    void Start()
    {
        
            
            while (!finishedNames)
            {
                if (i < 15)
                {
                    buttonText[i].text = buttonTextHolder.buttontexts[i];
                    i++;
                }
                else if (i == 15)
                {
                buttonText[i].text = buttonTextHolder.buttontexts[i];
                break;
                }
            }
    }

    // Update is called once per frame
    void Update()
    {
        scoreUi.text = "Score: " + score.ToString() + " / 16";
        
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
    public void OnValueChanged(int idOfOption)
    {
        if (idOfOption == 1)
        {
            Application.Quit();
            
        }
        if (idOfOption == 2)
        {
            Application.LoadLevel(2);

        }
        if (idOfOption == 3)
        {
            Reset();

        }
        if ( idOfOption == 4 ) {
            Application.LoadLevelAdditive (3);
            
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
