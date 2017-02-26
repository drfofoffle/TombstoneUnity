using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    public static float respawnFloat = 6;
    public static float Score = 0;
    public static bool GamePlayed = false;
    private bool trigger = false;
    public GameObject text;
    private Text txt;

    // Use this for initialization
    void Start () {
        respawnFloat = 6;
        txt = text.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if ((Score > 0) && (Application.loadedLevelName == "Menu"))
        {
            txt.text = ("Game Over! \n Score: " + Score);
        }

        if ((Score > 0) && (Application.loadedLevelName == "Main"))
        {
            txt.text = ("Score: " + Score);
        }

        if (Score == 0)
        {
            txt.text = ("");
        }
        if ((Score >= 0) && (Score <= 10))
        {
            respawnFloat = 6;
        }
        if ((Score > 10) && (Score <= 30))
        {
            respawnFloat = 3;
        }

        if (player.shot)
        {
            StartCoroutine(wait());
            //SceneManager.LoadScene("Menu");
            //player.shot = false;
        }

    }
    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(1);
        GamePlayed = true;
        SceneManager.LoadScene("Menu");
        player.shot = false;
    }
        //print(respawnFloat);


}
