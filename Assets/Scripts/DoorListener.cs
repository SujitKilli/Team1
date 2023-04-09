using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter()
    {
        Globals.isInDoor = true;
    }

    public void OnPointerExit()
    {
        Globals.isInDoor = false;
    }

    public void OnPointerEnterDoorBtn()
    {
        Globals.isInDoorBtn = true;
    }

    public void OnPointerExitDoorBtn()
    {
        Globals.isInDoorBtn = false;
    }
}

