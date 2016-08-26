using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour {

    public ButtonDisabler buttonDisabler;
    bool hovering = false;
	// Use this for initialization
	void Start () {
        buttonDisabler = GetComponent<ButtonDisabler>();
	}
	
	// Update is called once per frame
	void Update () {
	      if (!hovering)
        {

        }
	}
    void OnHoverDisabledButton()
    {

    }
}
