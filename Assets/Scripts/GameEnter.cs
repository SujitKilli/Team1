using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameEnter : MonoBehaviour
{
    // Start is called before the first frame update
    public bool inball;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inball==true && Input.GetButtonDown("js3"))
        {
            SceneManager.LoadScene("Game");
        }
    }
    public void Enter()
    {
        inball = true;
    }
    public void Exit()
    {
        inball = false;
    }
}
