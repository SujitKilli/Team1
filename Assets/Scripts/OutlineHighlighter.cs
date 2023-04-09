using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineHighlighter : MonoBehaviour
{
    private Outline myoutline;
    void Start()
    {
        myoutline = GetComponent<Outline>();
        myoutline.enabled = false;
    }

    void Update()
    {
    }

    public void OnPointerEnter()
    {
        if(Globals.hideOutline) myoutline.enabled = false;
        else myoutline.enabled = true;
    }

    public void OnPointerExit()
    {
        myoutline.enabled = false;
    }
}
