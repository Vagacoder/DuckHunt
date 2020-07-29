using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class of dog at the beginning DunkHuntPlay Scene
public class DogCatchDuck : MonoBehaviour
{
    private AudioSource audioBark;
    private bool audioPlayed = false;
    public float vSpeed = 1;
    public float movingUpTime = 1.4f;
    public float standTime = 2;
    public float movingDownime = 2;
    // Start is called before the first frame update
    void Start()
    {
        audioBark = GetComponent<AudioSource>();
        float currentTime = Time.time;
        movingUpTime += currentTime;
        standTime += movingUpTime;
        movingDownime += standTime;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        // event: moving up
        if (currentTime < movingUpTime){
            transform.position = new Vector2(transform.position.x, transform.position.y + vSpeed * Time.deltaTime);
        }

        // event: stand at top and play audio
        if (currentTime >= movingUpTime && currentTime < standTime){
            if (!audioPlayed){
                audioBark.Play();
                audioPlayed = true;
                }
        }

        // event: moving down
        if (currentTime >= standTime && currentTime < movingDownime){
           transform.position = new Vector2(transform.position.x, transform.position.y - vSpeed * Time.deltaTime);
        }

        // event: destroy game object
        if (currentTime >= movingDownime){
            Destroy(this.gameObject);
        }
    }
}
