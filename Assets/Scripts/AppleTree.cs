using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject appleprefab;
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
        GameObject apple = Instantiate(appleprefab,
        gameObject.transform.position + new Vector3(Random.Range(-8f, 8f),Random.Range(15f, 30f),
        Random.Range(-8f, 8f)), Quaternion.Euler(270, 0, 0),gameObject.transform);
        apple.transform.localScale = apple.transform.localScale*0.25f;
        apple.SetActive(true);
    }
}
