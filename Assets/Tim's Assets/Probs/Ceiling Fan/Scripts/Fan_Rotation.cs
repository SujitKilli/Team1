using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fan_Rotation : MonoBehaviour {
    //public bool isRotating = false;
    public bool TurnOn = false;
    public float speed = 500;
    private bool isFanOn = false;
    void Start(){

    }

    void Update () {

        if(isFanOn){
               transform.Rotate((new Vector3(0, 1, 0)) * Time.fixedDeltaTime * speed); 
        }

        if (Input.GetButtonDown(Globals.x)) // Check if button "js8" is pressed
        {
            if(TurnOn && !isFanOn){
                isFanOn = true;
            }
            else if(TurnOn){
                isFanOn = false;
            }
        }
    
    }
    public void OnEnter(){
        TurnOn=true;

    }
    public void OnExit(){
        TurnOn=false;
    }
            
	
}





