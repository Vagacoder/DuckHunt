using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DuckHuntStartSceneController : MonoBehaviour
{
    private bool playDuckHunt = false;

    // after click play button, wait for 1.5 seconds to load DuckHuntPlay
    private float loadTime = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playDuckHunt && Time.time>= loadTime)
        {loadDuckHuntPlay();}
    }

    public void DuckHuntPlayStart(){
        playDuckHunt = true;
        loadTime += Time.time;
    }
    public void loadDuckHuntPlay()
    {    playDuckHunt = false;
        SceneManager.LoadScene("DuckHuntPlay");
       
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
