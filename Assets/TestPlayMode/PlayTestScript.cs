using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


namespace Tests
{
    public class PlayTestScript
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator SceneLoading_Test()
        {
            SceneManager.LoadScene("Start");

             yield return new WaitForSeconds(2);
             Assert.AreEqual(SceneManager.GetActiveScene().name, "Start");

            //  var canvas = GameObject.FindWithTag("Canvas");
            //  canvas.GetComponent<SceneController>().loadRTSmode();

            this.loadRTSmode();
             
             yield return new WaitForSeconds(2);
             Assert.AreEqual(SceneManager.GetActiveScene().name, "RTS_Scene");
         
            SceneManager.LoadScene("Start");

             yield return new WaitForSeconds(2);
             Assert.AreEqual(SceneManager.GetActiveScene().name, "Start");

             this.loadSTGmode();
             yield return new WaitForSeconds(2);
             Assert.AreEqual(SceneManager.GetActiveScene().name, "STG_Scene");

            SceneManager.LoadScene("Start");
             yield return new WaitForSeconds(2);
            Assert.AreEqual(SceneManager.GetActiveScene().name, "Start");

             this.loadFPSmode();
             yield return new WaitForSeconds(2);
             Assert.AreEqual(SceneManager.GetActiveScene().name, "FPS_Scene");

             SceneManager.LoadScene("Start");
             yield return new WaitForSeconds(2);
             Assert.AreEqual(SceneManager.GetActiveScene().name, "Start");

             this.loadSetting();
             yield return new WaitForSeconds(2);
            Assert.AreEqual(SceneManager.GetActiveScene().name, "Setting");
            yield return null;
        }

    // methods copied from Scripts/SceneController()============================
    public void loadRTSmode()
    {
        //Application.LoadLevel("RTS_Scene");
        SceneManager.LoadScene("RTS_Scene");
    }

    public void loadSTGmode()
    {
        //Application.LoadLevel("STG_Scene");
        SceneManager.LoadScene("STG_Scene");
    }

    public void loadFPSmode()
    {
        //Application.LoadLevel("FPS_Scene");
        SceneManager.LoadScene("FPS_Scene");
    }

    public void loadSetting()
    {
        //Application.LoadLevel("Setting");
        SceneManager.LoadScene("Setting");
    }

    public void quitGame()
    {
        Application.Quit();
    }
    //=================================================================
    }
}
