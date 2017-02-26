using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGame : MonoBehaviour {
    public Text txt;
    // Use this for initialization
    void Start () {
        txt.alignment = TextAnchor.MiddleCenter;
    }
	
	// Update is called once per frame
	void Update () {
	    if (GameControl.GamePlayed==false)
        {
            txt.text = ("Shoot me \n to play!");
        }

        if (GameControl.GamePlayed == true)
        {
            txt.text = ("Shoot me \n to play again!");
        }
    }

    void HitByRay()
    {
        StartCoroutine(Begin());
    }

    private IEnumerator Begin()
    {
        yield return new WaitForSeconds(0.5f);
        GameControl.Score = 0;
        SceneManager.LoadScene("Main");
    }
}
