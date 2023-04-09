using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    public ChangingOptions cmenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cmenu.index==0 && (Input.GetButtonDown("js3")))
        {
            SceneManager.LoadScene("Beach");
        }
    }
    
}
