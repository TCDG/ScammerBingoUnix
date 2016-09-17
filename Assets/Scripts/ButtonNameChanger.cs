using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonNameChanger : MonoBehaviour {

    public ButtonTextHolder buttonTextHolder;
    public InputField[] inputField = new InputField[16];
    int i = 0;
    bool finishedNames = false;
    // Use this for initialization
    void Start () {
        while (!finishedNames)
        {
            
            if (i < 15)
            {
                inputField[i].text = buttonTextHolder.buttontexts[i];
                i++;
            }
            else if (i == 15)
            {
                inputField[i].text = buttonTextHolder.buttontexts[i];
                break;
            }
        }
    }
    public void ChangeTheText()
    {
        i = 0;
        while(!finishedNames)
        {
            if (i < 15)
            {
                buttonTextHolder.buttontexts[i] = inputField[i].text;
                i++;
            }
            else if (i == 19)
            {
                buttonTextHolder.buttontexts[i] = inputField[i].text;
                break;
            }
        }
    }
    // Update is called once per frame
    void Update () {
	
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
