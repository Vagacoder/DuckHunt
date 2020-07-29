using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DuckController : MonoBehaviour
{
    public float vSpeedAtStart;
    public float hSpeedAtStart;

    // unit is 0.1 seconds
    public int minTimeOfTurnDirection;

    // unit is 0.1 seconds
    public int maxTimeOfTurnDirection;
    //private float timeOfTurnDirection;
    private float vSpeed;
    private float hSpeed;
    private int direction;

    public enum FlyStatus
    {
        Raising, FlyHorizontal
    }
    private FlyStatus flyStatus;

    private float currentX;
    private float currentY;
    private float nextTurnTimeStamp;
    private float boundaryX = 6.2f;
    private Animator duckAnimator;
    private AudioSource hitCry;
    private bool isHit =false;
    private float timeStampStartToFall;
    private DuckHuntPlayGameController gameController;

    // Start is called before the first frame update
    void Start()
    {   
        gameController = FindObjectOfType<DuckHuntPlayGameController>();
        duckAnimator = this.GetComponent<Animator>();
        hitCry = GetComponent<AudioSource>();
        Vector2 currentPosition = this.transform.position;
        currentX = currentPosition.x;
        currentY = currentPosition.y;
        // determine initial flying direction ans speed
        if (currentX > 0)
        {
            direction = -1;
            this.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            direction = 1;
        }

        // At start stage of fly, move fast at vertial, move slow at horizontal
        hSpeed = direction * hSpeedAtStart * 0.3f;
        vSpeed = vSpeedAtStart *2.0f;
        flyStatus = FlyStatus.Raising;

        // set the time stamp for next turnning point
        nextTurnTimeStamp = Time.time + Random.Range(minTimeOfTurnDirection, maxTimeOfTurnDirection) / 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        checkFlyingStatus();
        startToFall();
        outOfBoundartForDestroy();
        flyDirectionControl();
        boundaryChecking();

        this.transform.position += new Vector3(Time.deltaTime * hSpeed, Time.deltaTime * vSpeed, 0);

    }

    // Hit event
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Target-Duck" && !isHit) {
            duckAnimator.SetTrigger("Hit");
            hitCry.Play();
            isHit = true;
            gameController.oneDuckHit();
            timeStampStartToFall = Time.time + 1.0f;
            hSpeed = 0;
            vSpeed = 0;
            //Destroy(other.gameObject);
        }
    }

    void checkFlyingStatus(){
        if (transform.position.y > -0.5 && !isHit && flyStatus == FlyStatus.Raising){
            duckAnimator.SetBool("FlyHorizontal", true);
            flyStatus = FlyStatus.FlyHorizontal;

        }

        if (transform.position.y > -0.4 && !isHit && flyStatus == FlyStatus.FlyHorizontal){
            hSpeed = direction * hSpeedAtStart;
            vSpeed = vSpeedAtStart;
        }
    }

    // control duck flying behavior
    void flyDirectionControl()
    {
        // if turning time stamp reaches, turn the moving direction and speed.
        if (nextTurnTimeStamp < Time.time && !isHit)
        {
            nextTurnTimeStamp = Time.time + Random.Range(minTimeOfTurnDirection, maxTimeOfTurnDirection) / 10.0f;
            direction = -direction;
            determineSpriteFlip();
            hSpeed = -hSpeed;
        }
    }

    // boundary checking
    void boundaryChecking()
    {
        if (transform.position.x > boundaryX && transform.position.y < 4.0f)
        {
            direction =  -1;
            determineSpriteFlip();
            hSpeed = -Mathf.Abs(hSpeed);
        } else if (transform.position.x < -boundaryX && transform.position.y < 4.0f){
            direction =  1;
            determineSpriteFlip();
            hSpeed = Mathf.Abs(hSpeed);
        }
    }

    // determinate whether flip the sprite.
    void determineSpriteFlip(){
        if (direction > 0)
            {
                this.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                this.transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
    }

    void outOfBoundartForDestroy(){
        if (this.transform.position.y > 6 || this.transform.position.y < -6){
            Destroy(this.gameObject);
        }
    }

    // 1 second after hit, starting to fall
    void startToFall(){
        if (isHit && Time.time > timeStampStartToFall){
            vSpeed = -3;
            duckAnimator.SetTrigger("Fall");
        }
    }
}
