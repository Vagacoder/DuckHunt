using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckHuntPlayDogStart : MonoBehaviour
{
    public float hSpeed;
    public float vSpeed;
    private Animator dogStartAnimator;
    private AudioSource bark;
    private bool isBarked = false;
    private Vector3 startPosition;
    private float startTime;


    // set time stamps of events
    private float dogFindTimeStamp = 5.0f;
    //private bool isDogFindStarted = false;
    private float dogJumpTimeStamp = 5.5f;
    //private bool isDogJumpStarted = false;
    private float dogHideTimeStamp = 6.5f;
    //private bool isDogHindStarted = false;
    private float dogDestroyTimeStamp = 7.5f;


    // Start is called before the first frame update
    void Start()
    {
        dogStartAnimator = GetComponent<Animator>();
        bark = GetComponent<AudioSource>();
        startPosition = transform.position;
        startTime = Time.time;
        dogFindTimeStamp += startTime;
        dogJumpTimeStamp += startTime;
        dogHideTimeStamp += startTime;
        dogDestroyTimeStamp += startTime;
    }

    // Update is called once per frame
    void Update()
    {   float currentTime = Time.time;

        // event: dog moving, from start to dogFindTimeStamp
        if (currentTime < dogFindTimeStamp){
        Vector3 currentPosition = transform.position;
        transform.position = new Vector3(currentPosition.x + hSpeed * Time.deltaTime,
             currentPosition.y , currentPosition.z);}

        // event: dog find, from dogFindTimeStamp to dogJumpTimeStamp
        else if ( currentTime >= dogFindTimeStamp && currentTime < dogJumpTimeStamp){
            dogStartAnimator.SetTrigger("Find");            
        }

        // event: dog jump, from dogJumpTimeStamp to dogHideTimeStamp
        else if (currentTime >= dogJumpTimeStamp && currentTime < dogHideTimeStamp){
            if (!isBarked){
                bark.Play();
                isBarked = true;
                }
            dogStartAnimator.SetTrigger("Jump");
            Vector3 currentPosition = transform.position;
            transform.position = new Vector3(currentPosition.x + hSpeed * Time.deltaTime,
             currentPosition.y + vSpeed * Time.deltaTime, currentPosition.z);}


        // event: dog hide, from dogHideTimeStamp to dogDestroyTimeStamp
        else if (currentTime >= dogHideTimeStamp && currentTime < dogDestroyTimeStamp){
            dogStartAnimator.SetTrigger("Hide");
        } 
        
        // event: destoy dog_start
        else {
            Destroy(this.gameObject);
        }


    }
}
