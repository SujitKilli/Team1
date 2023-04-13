using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingOptions : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] buttons;
    public Button[] helpbutton;
    public GameObject menu;
    public GameObject help;
    public GameObject character;
    public GameObject xr;
    public GameObject rectile;
    public int index = 0;
    public int helpindex = 0;
    public bool ishelphighlighted;
    private float lasttime;
    void Start()
    {
        buttons = menu.GetComponentsInChildren<Button>();
        helpbutton = help.GetComponentsInChildren<Button>();
        character.GetComponent<CharacterMovement>().enabled = false;
        xr.GetComponent<XRCardboardController>().enabled = false;
        HighlightButton(index);
    }

    // Update is called once per frame
    void Update()
    {
        if (menu.activeSelf == true)
        {
            rectile.SetActive(false);
            if (Time.time - lasttime > 0.5f)
            {
                if (Input.GetAxis(Globals.ver) > 0)
                {
                    index--;
                    if (index < 0)
                    {
                        index = buttons.Length - 1;
                    }
                    HighlightButton(index);
                    lasttime = Time.time;
                }
                else if (Input.GetAxis(Globals.ver) < 0)
                {
                    index++;
                    if (index >=buttons.Length)
                    {
                        index = 0;
                    }
                    HighlightButton(index);
                    lasttime = Time.time;
                }
                else if (Input.GetAxis(Globals.hor) > 0)
                {
                    foreach (Button b in buttons)
                    {
                        b.image.color = Color.white;
                    }
                    helpbutton[helpindex].image.color = Color.yellow;
                    ishelphighlighted = true;
                    lasttime = Time.time;
                    index = -1;
                }
                else if (Input.GetAxis(Globals.hor) < 0)
                {
                    ishelphighlighted = false;
                    helpbutton[helpindex].image.color = Color.white;
                    index = 0;
                    HighlightButton(index);
                    lasttime = Time.time;                    
                }
            }


        }

    }
    public void HighlightButton(int index)
    {
        foreach (Button b in buttons)
        {
            b.image.color = Color.white;
        }
        buttons[index].image.color = Color.yellow;
    }
}
