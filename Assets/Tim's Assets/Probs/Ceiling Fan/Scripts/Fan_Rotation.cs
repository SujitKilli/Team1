using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Fan_Rotation : MonoBehaviour {
	public GameObject fan;
	// public GameObject menu;
	// public GameObject reticle;
    // public CharacterController character;
	public bool TurnOn = false;
	public float speed=500;
	// public Button[] buttons;
    // public int index;
    // public float lasttime;
    public bool isRotating = false;

void start() 
{
//Fan Rotates in Y axis
		if(TurnOn == true && Input.GetButtonDown("js8") )
		{
			while(!isRotating)
			{
				transform.Rotate((new Vector3(0,1,0)) * Time.fixedDeltaTime*speed);
                if(TurnOn == true && Input.GetButtonDown("js8"))
                transform.Rotate(Vector3.zero);
			}
			
		}
}
	
void Update () {
	// if(Input.GetButtonDown("js8"))
    //     {
    //         if(TurnOn == true && menu.activeSelf==false)
    //     {
    
    //         menu.SetActive(true);
    //         menu.transform.position=fan.transform.position+new Vector3(0,0.8f,0);
    //         reticle.SetActive(false);
    //         character.enabled=false;
            
    //     }
    //     else if(menu.activeSelf==true){
    //         menu.SetActive(false);
    //         reticle.SetActive(true);
    //         character.enabled=true;
    //     }

    //     }
         
    //     if(menu.activeSelf==true){
            
    //             if (Time.time - lasttime > 0.5f)
    //         {
    //             if (Input.GetAxis("Vertical") > 0)
    //             {
    //                 index--;
    //                 if (index < 0)
    //                 {
    //                     index = buttons.Length - 1;
    //                 }
    //                 HighlightButton(index);
    //                 lasttime = Time.time;
    //             }
    //             else if (Input.GetAxis("Vertical") < 0)
    //             {
    //                 index++;
    //                 if (index >= buttons.Length)
    //                 {
    //                     index = 0;
    //                 }
    //                 HighlightButton(index);
    //                 lasttime = Time.time;
    //             }
    //         }
    //         if(index==0 && Input.GetButtonDown("js10")){
	// 			transform.Rotate((new Vector3(0,1,0)) * Time.fixedDeltaTime*speed);
            
    //     }
    //     else if(index==1 && Input.GetButtonDown("js10")){
	// 		transform.Rotate(Vector3.zero);
            
    //     }
        

    //     }
        
        
    // }
   
    // public void HighlightButton(int index)
    // {
    //     foreach (Button b in buttons)
    //     {
    //         b.image.color = Color.white;
    //     }
    //     buttons[index].image.color = Color.yellow;
        
    // }
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



	 
		
		
		
	


	

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Fan_Rotation : MonoBehaviour {
//     public bool isRotating = false;
//     public bool TurnOn = false;
//     public float speed = 500;

//     void Update () {
//         if (Input.GetButtonDown("js8")) // Check if button "js8" is pressed
//         {
//             TurnOn = !TurnOn; // Toggle TurnOn variable
//         }

//         if (TurnOn)
//         {
//             if (!isRotating)
//             {
//                 isRotating = true;
//                 transform.Rotate((new Vector3(0, 1, 0)) * Time.fixedDeltaTime * speed);
//             }
//         }
//         else
//         {
//             if (isRotating)
//             {
//                 isRotating = false;
//                 transform.Rotate(Vector3.zero);
//             }
//         }
//     }
	
// }





