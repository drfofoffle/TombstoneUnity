using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
    
    AudioSource audio;
    public static bool shot = false;
    public AudioClip death;
    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
	
	}

    void GotShot()
    {
        audio.PlayOneShot(death, 1f);
        shot = true;
        print("hit");
    }
}
