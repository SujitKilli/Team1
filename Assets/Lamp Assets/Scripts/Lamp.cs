using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour {

   
    public GameObject LampLight;

   
    public GameObject DomeOff;

  
    public GameObject DomeOn;

    public bool TurnOn=false;
    
    

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        
        if(TurnOn==true && Input.GetButtonDown(Globals.x))
        {

    

        if (LampLight.activeSelf == false)
        {
           
            LampLight.SetActive(true);
            DomeOff.SetActive(false);
            DomeOn.SetActive(true);
        }
        else if(LampLight.activeSelf)
        {
            LampLight.SetActive(false);
            DomeOff.SetActive(true);
            DomeOn.SetActive(false);
           
        }
        }

        

        
       
    }
   public void OnPointEnter()
    {
        Debug.Log("Entered ");
        TurnOn=true;

    }
    public void OnPointerExit()
    {
        Debug.Log("Exit");
        TurnOn = false;
    }

   
}
