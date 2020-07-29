using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningDogTitle : MonoBehaviour

{
    
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentX = this.transform.position.x;
        currentX += + Time.deltaTime * speed;
        transform.position = new Vector3 (currentX, transform.position.y, transform.position.z);
        if (currentX > 8.5 )
        {
            Destroy(this.gameObject);
        }
    }
}
