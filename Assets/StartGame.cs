using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
