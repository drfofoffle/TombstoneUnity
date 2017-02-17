using UnityEngine;
using System.Collections;
public class TargetShoot : MonoBehaviour
{
    AudioClip Gun;
    public AudioClip HitNoise;
    public AudioSource SoundSource;
    public GameObject GunEnd;
    public AudioClip gunShot;
    public float timeLeft = 15;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControl.Score >= transform.root.GetComponent<TargetY>().appearenceScore)
        {
            Debug.DrawRay(GunEnd.transform.position, GunEnd.transform.forward, Color.green);
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                 //plays firing noise
                timeLeft = 10; //resets timer
                RaycastHit TargetHit;
                SoundSource.PlayOneShot(gunShot);
                Instantiate(Resources.Load<GameObject>("SmokeEffect"), GunEnd.transform.position, GunEnd.transform.rotation);
                if (Physics.Raycast(transform.position, GunEnd.transform.forward, out TargetHit))
                {
                    TargetHit.transform.SendMessage("GotShot");
                }



            }


        }
    }

}
