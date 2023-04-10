using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    public ChangingOptions cmenu;
    public GameObject exitpanel;
    public GameObject menu;
    public GameObject helpmenu;
    public Button[] exitbuttons;
    public int exitindex = 0;
    private float lasttime;
    void Start()
    {
        //character.enabled = false;
        exitbuttons = exitpanel.GetComponentsInChildren<Button>();
        HighlightButton(exitindex);

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(cmenu.index);
        if (cmenu.index == 2 && Input.GetButtonDown(Globals.ok))
        {
            exitpanel.SetActive(true);
            menu.SetActive(false);
            helpmenu.SetActive(false);
        }
            if (exitpanel.activeSelf == true)
            {
            //Debug.Log("inexit");
                if (Time.time - lasttime > 0.5f)
                {
                //Debug.Log("inhorizontal")
                    if (Input.GetAxis(Globals.hor) < 0)
                    {
                        exitindex--;
                        Debug.Log(exitindex);
                        if (exitindex < 0)
                        {
                            exitindex = exitbuttons.Length - 1;
                        }
                        HighlightButton(exitindex);
                        lasttime = Time.time;
                    }
                    else if (Input.GetAxis(Globals.hor)  > 0)
                    {
                        exitindex++;
                        if (exitindex >= exitbuttons.Length)
                        {
                            exitindex = 0;
                        }
                        HighlightButton(exitindex);
                        lasttime = Time.time;
                    }
                }
            }
    }
    public void HighlightButton(int index)
    {
        foreach (Button b in exitbuttons)
        {
            b.image.color = Color.white;
        }
        exitbuttons[index].image.color = Color.yellow;
    }

}
