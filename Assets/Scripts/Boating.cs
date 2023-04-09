using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boating : MonoBehaviour
{
    private Outline myoutline;
    private bool inflag = false; 
    public GameObject boatMenu,paddle1,paddle2;
    private bool takeAxes = true;
    private float pad1dir=-30f,pad2dir = 30f;
    // Start is called before the first frame update
    void Start()
    {
        myoutline = GetComponent<Outline>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown(Globals.x)){
            if(myoutline.enabled && !boatMenu.activeSelf && !inflag){
                Globals.boatSitter = gameObject;
                inflag = true;
                Vector3 towardsCamera = (Camera.main.transform.position - gameObject.transform.position).normalized;
                boatMenu.SetActive(true);
                boatMenu.transform.position = gameObject.transform.position + towardsCamera*9f + new Vector3(0,20f,0);
                boatMenu.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
            }
            else if(boatMenu.activeSelf && inflag){
                Globals.boatSitter = null;
                inflag = false;
                boatMenu.SetActive(false);
            }
        }
        if(Globals.boatsat && Globals.boatSitter == gameObject){
            transform.position = new Vector3(Camera.main.transform.position.x,transform.position.y,Camera.main.transform.position.z);
            if(paddle1.transform.rotation.y < -180) pad1dir = 30f;
            else if(paddle1.transform.rotation.y > 0) pad1dir = -30f;

            if(paddle2.transform.rotation.y < 0) pad2dir = 30f;
            else if(paddle2.transform.rotation.y > 180) pad2dir = -30f;

            Quaternion pad1rot = paddle1.transform.rotation;
            Quaternion pad2rot = paddle2.transform.rotation;

            paddle1.transform.rotation = Quaternion.Euler(pad1rot.eulerAngles.x, pad1rot.eulerAngles.y + pad1dir * Time.deltaTime, pad1rot.eulerAngles.z);
            paddle2.transform.rotation = Quaternion.Euler(pad2rot.eulerAngles.x, pad2rot.eulerAngles.y + pad2dir * Time.deltaTime, pad2rot.eulerAngles.z);
            if(Input.GetAxis(Globals.hor) < 0 && takeAxes){
                takeAxes = false;
                StartCoroutine(ReEnableAxes());
                transform.rotation = transform.rotation * Quaternion.AngleAxis(-500f*Time.deltaTime, Vector3.up);
            }
            else if(Input.GetAxis(Globals.hor) > 0 && takeAxes) {
                takeAxes = false;
                StartCoroutine(ReEnableAxes());
                transform.rotation = transform.rotation * Quaternion.AngleAxis(500f*Time.deltaTime, Vector3.up);
            }
        }
        if(!boatMenu.activeSelf) inflag = false;
    }

    IEnumerator ReEnableAxes() {
        yield return new WaitForSeconds(0.5f);
        takeAxes = true;
    }
}
