using UnityEngine;
using System.Collections;

public class Flash : MonoBehaviour {

    private Renderer myRenderer;
    private bool muzzleFlash;
	// Use this for initialization
	void Start ()
    {
        myRenderer = GetComponent<Renderer>();
        myRenderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update()
    {
        //print(muzzleFlash);
        if (TEst.Flash)
        {
            StartCoroutine(Flashing());
            TEst.Flash = false;
        }
    }

    IEnumerator Flashing ()
    {
        myRenderer.enabled = true;
        yield return new WaitForSeconds(0.2f);
        myRenderer.enabled = false;
    }
}
