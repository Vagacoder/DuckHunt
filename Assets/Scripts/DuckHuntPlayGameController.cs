using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DuckHuntPlayGameController : MonoBehaviour
{

    public DuckController duckBrown;
    public DuckController duckRed;
    public AmmoController ammoPanel;
    public GameObject duckHitPair;
    public GameObject dogCatch0Duck;
    public GameObject dogCatch1Duck;
    public GameObject dogCatch2Duck;
    public CrossDuck crossHair;

    private int ammo = 3;
    private int hitNumber = 0;
    private int gameScore = 0;
    private bool isShootStart = false;
    private bool isGameOver = false;
    private bool isGmaePause = false;

    private int currentRound = 0;
    private int maxRound = 5;
    private float timeOfOneRound = 15.0f;
    private float startTime;
    private float nextRoundStartTime = 9.0f;
    private float nextDogShowingTime;
    //private float round2StartTime;

    //private bool round1Started = false;
    //private bool round2Started = false;
    //private bool round3Started = false;
    //private bool round4Started = false;
    //private bool round5Started = false;

    private float duck_vSpeedAtStart = 1;
    private float duck_HSpeedAtStart = 5;
    private float duck_spawnYCorMax = -3.0f;
    private float duck_spawnYCorMin = -4.0f;
    private float duck_spawnXCorMax = 6.5f;
    private float duck_spawnXCorMin = -6.5f;
    // unit is 0.1 seconds
    private int duck_minTimeOfTurnDirection = 12;
    // unit is 0.1 seconds
    private int duck_maxTimeOfTurnDirection = 15;

    private float dog_spawnYCordination = -2.5f;

    public Text roundNumber;
    private float UIroundNumberTextDisableTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Set Cursor to not be visible
        startTime= Time.time;
        nextDogShowingTime = nextRoundStartTime + 9.5f;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;

        if (!isGameOver && currentRound > maxRound){
            isGameOver = true;
            roundNumber.text = "Press ENTER to menu";
        }
        // Game is over
        if (isGameOver) {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("DuckHuntStart");
            }
        }

        // update UI
        if (!isGameOver && currentTime > UIroundNumberTextDisableTime){
            roundNumber.text = "";
        }

        // check ammo
        if (ammo <= 0) {
            ammoPanel.setAmmoTo0();
        } else if (ammo == 1){
            ammoPanel.setAmmoTo1();
        } else if (ammo == 2){
            ammoPanel.setAmmoTo2();
        } else if (ammo == 3){
            ammoPanel.resetAmmo();
        }

        // click mouse left button to fire
        if (isShootStart && !isGameOver && (ammo > 0) && Input.GetMouseButtonDown(0))
        {
            crossHair.Fire();
            ammo--;
         }

        // round start
        if (!isGameOver && (currentTime - startTime) >= nextRoundStartTime  ){
            if (currentRound ==0){
                currentRound++;
            }
            roundInitialEvents();
            nextRoundStartTime += timeOfOneRound;
        }

        // round end events (dog showing)
        if (!isGameOver && (currentTime - startTime) >= nextDogShowingTime){
            dogShowResult();
            nextDogShowingTime += timeOfOneRound;
            currentRound++;
        }
        
    }

    // events initialization for each round 
    void roundInitialEvents(){
        float currentTime = Time.time;
        roundNumber.text = "Round " + currentRound;
        UIroundNumberTextDisableTime = currentTime + 0.5f;
        isShootStart = true;
        ammo = 3;
        ammoPanel.resetAmmo();
        hitNumber = 0;
        float duck_x = Random.Range(duck_spawnXCorMin, duck_spawnXCorMax);
        float duck_y = Random.Range(duck_spawnYCorMin, duck_spawnYCorMax);
        Instantiate(duckBrown, (new Vector3(duck_x, duck_y, 0)), Quaternion.identity);
        if (duck_x >=0){
            duck_x = Random.Range(duck_spawnXCorMin, 0);
        } else {
            duck_x = Random.Range(0, duck_spawnXCorMax);
        }
        duck_y = Random.Range(duck_spawnYCorMin, duck_spawnYCorMax);
        Instantiate(duckRed, (new Vector3(duck_x, duck_y, 0)), Quaternion.identity);
    }

    // round end event (dog showing)
    void dogShowResult(){
        if (hitNumber <= 0){
            Instantiate(dogCatch0Duck, (new Vector3(-1, dog_spawnYCordination, 0)), Quaternion.identity);
        } else if (hitNumber == 1){
            Instantiate(dogCatch1Duck, (new Vector3(-1, dog_spawnYCordination, 0)), Quaternion.identity);
        } else if (hitNumber == 2){
            Instantiate(dogCatch2Duck, (new Vector3(-1, dog_spawnYCordination, 0)), Quaternion.identity);
        }
    }

    public void oneDuckHit(){
        hitNumber++;
    }
}
