using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatingBtn : MonoBehaviour
{
    private bool isEnter = false;
    public GameObject boatMenu,character,reticle; 
    private CharacterMovement cm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnter && Globals.boatSitter != null && Input.GetButtonDown(Globals.ok)){
            Globals.boatsat = true;
            Globals.ypos = Camera.main.transform.position.y;
            Camera.main.transform.position = new Vector3(Globals.boatSitter.transform.position.x,Globals.boatSitter.transform.position.y+20f,Globals.boatSitter.transform.position.z);
            boatMenu.SetActive(false);
            Globals.ToggleBoundaries(true);
            reticle.transform.localScale = new Vector3(0,0,0);
            Globals.boatSitter.GetComponent<WaterFloat>().enabled = false;
        }
        
    }

    public void OnPointerEnter()
    {
        isEnter = true;
    }

    public void OnPointerExit()
    {
        isEnter = false;
    }
}
