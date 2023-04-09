using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeachTree : MonoBehaviour
{
    public GameObject peachprefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<15;i++){
            createChildFruits();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createChildFruits(){
        GameObject peach = Instantiate(peachprefab,
        gameObject.transform.position + new Vector3(Random.Range(-5f, 5f),Random.Range(15f, 30f),
        Random.Range(-5f, 5f)), Quaternion.Euler(270, 0, 0),gameObject.transform);
        peach.transform.localScale = peach.transform.localScale*0.25f;
        peach.SetActive(true);
    }
}
