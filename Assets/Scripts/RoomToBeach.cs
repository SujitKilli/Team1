using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomToBeach : MonoBehaviour
{
    // Start is called before the first frame update
    private Outline myOutline;
    void Start()
    {
         myOutline=GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myOutline.enabled && Input.GetButtonDown(Globals.x)){
            SceneManager.LoadScene("Beach");
        }
    }
}
