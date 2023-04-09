using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPond : MonoBehaviour
{
    public GameObject fishPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<15;i++){
            createFish();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createFish(){
        GameObject fish = Instantiate(fishPrefab,
        gameObject.transform.position + new Vector3(Random.Range(-40f, 40f),Random.Range(2f, 4f),
        Random.Range(-40f, 40f)), Quaternion.identity);
        fish.SetActive(true);
    }
}
