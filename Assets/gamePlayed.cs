using UnityEngine;
using System.Collections;

public class gamePlayed : MonoBehaviour {

    public Component targetYScript;
    void Start () {
        targetYScript = GetComponent<TargetY>();
    }

    // Update is called once per frame
    void Update () {
	    if (GameControl.GamePlayed == false)
        {
            GetComponent<TargetY>().enabled = false;
        }

        if (GameControl.GamePlayed == true)
        {
            GetComponent<TargetY>().enabled = true;
        }
    }

}
