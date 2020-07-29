using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckHuntStartSoundController : MonoBehaviour
{

    public AudioSource[] soundAndBGM;

    private AudioSource startingBGM;
    private AudioSource BGMofPlayButton ;

    // Start is called before the first frame update
    IEnumerator Start()
    {
                // find starting BGM
        startingBGM = soundAndBGM[0];
        BGMofPlayButton = soundAndBGM[1];
        yield return new WaitForSeconds(1.0f);
        startingBGM.Play();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playBGMofPlayButton()
    {
        startingBGM.Stop();
        BGMofPlayButton.Play();
    }
}
