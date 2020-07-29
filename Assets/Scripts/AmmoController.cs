using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{

    public Sprite[] spriteArray;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = spriteArray[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetAmmo(){
        GetComponent<SpriteRenderer>().sprite = spriteArray[3];
    }
    public void setAmmoTo2(){
        GetComponent<SpriteRenderer>().sprite = spriteArray[2];
    }

    public void setAmmoTo1(){
        GetComponent<SpriteRenderer>().sprite = spriteArray[1];
    }

    public void setAmmoTo0(){
        GetComponent<SpriteRenderer>().sprite = spriteArray[0];
    }
}
