using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundHitRecord : MonoBehaviour
{
    public Sprite[] spriteArray;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = spriteArray[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void hit1Duck(){
        GetComponent<SpriteRenderer>().sprite = spriteArray[1];
    }

    void hit2Duck(){
        GetComponent<SpriteRenderer>().sprite = spriteArray[2];
    }
}
