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
        if (!exitpanel.activeSelf && cmenu.index == 2 && Input.GetButtonDown(Globals.ok))
        {
            exitpanel.SetActive(true);
            menu.SetActive(false);
            helpmenu.SetActive(false);
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
