using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossDuck : MonoBehaviour
{
    public GameObject ClickPoint;
    public Boundary boundary;
    public Sprite[] spriteArray;
    public AudioSource fire;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = spriteArray[PlayerStates.CrossType];
    }

    // Update is called once per frame
    void Update()
    {
        //=============================================================================
        // this block is for moving crosshair
        //=============================================================================
        // move crosshair to current mouse position, please note ScreenToWorldPoint()
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Clamp(mousePosition.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(mousePosition.y, boundary.yMin, boundary.yMax));
    }

    public void Fire(){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(ClickPoint, new Vector3(mousePosition.x, mousePosition.y, 0), Quaternion.identity);
            fire.Play();
    }
}
