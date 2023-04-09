using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExitPanelClose : MonoBehaviour
{
    // Start is called before the first frame update
    public Exit exitpanel;
    public GameObject panel;
    public ChangingOptions cmenu;
    private float lasttime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (exitpanel.exitpanel.activeSelf == true)
        {
            //Debug.Log("inexit");
            if (Time.time - lasttime > 0.5f)
            {
                //Debug.Log("inhorizontal")
                if (Input.GetAxis("Horizontal") > 0)
                {
                    exitpanel.exitindex--;
                    //Debug.Log(exitpanel.exitindex);
                    if (exitpanel.exitindex < 0)
                    {
                        exitpanel.exitindex = exitpanel.exitbuttons.Length - 1;
                    }
                    HighlightButton(exitpanel.exitindex);
                    lasttime = Time.time;
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    exitpanel.exitindex++;
                    if (exitpanel.exitindex >= exitpanel.exitbuttons.Length)
                    {
                        exitpanel.exitindex = 0;
                    }
                    HighlightButton(exitpanel.exitindex);
                    lasttime = Time.time;
                }
            }
        }

        if (exitpanel.exitindex==1 && Input.GetButtonDown("js3"))
        {
            panel.SetActive(false);
            cmenu.menu.SetActive(true);
            cmenu.help.SetActive(true);
        }
        else if(exitpanel.exitindex==0 && Input.GetButtonDown("js3"))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
    public void HighlightButton(int index)
    {
        foreach (Button b in exitpanel.exitbuttons)
        {
            b.image.color = Color.white;
        }
        exitpanel.exitbuttons[index].image.color = Color.yellow;
        //Debug.Log(exitpanel.exitbuttons[index].GetComponentInChildren<Text>());
        //Debug.Log(index);
        //ishighlighted = true;
    }
}
