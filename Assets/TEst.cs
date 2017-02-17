using UnityEngine;
using System.Collections;

public class TEst : MonoBehaviour {
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    public bool gripButtonDown = false;
    public GameObject barrelEnd;
    public bool gripButtonUp = false;
    public bool gripButtonPressed = false;
    public float bulletSpeed = 10;
    public Rigidbody bullet;
    public float FireSpeed;
    public GameObject smoke;
    public GameObject colt;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public bool triggerButtonDown = false;
    public bool triggerButtonUp = false;
    public bool triggerButtonPressed = false;
    public ushort Haptic;
    public float strength;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;
    public AudioClip GunNoise;
    public AudioClip HitNoise;
    private AudioSource Source;
    private float WaitTime;
    public GameObject GunEnd;
    private float counter = 0;
    public static bool Flash = false;
    private float waitTime;

    // Use this for initialization
    void Start () {
        Source = GetComponent<AudioSource>();
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {

        Debug.DrawRay(transform.position, GunEnd.transform.forward, Color.green);

        triggerButtonDown = controller.GetPressDown(triggerButton);
        triggerButtonUp = controller.GetPressUp(triggerButton);
        triggerButtonPressed = controller.GetPress(triggerButton);

        if (triggerButtonDown && Time.time > WaitTime)
            {
            WaitTime = Time.time + FireSpeed; //Firing Cooldown time 
            Debug.Log("Trigger Button was just pressed");
            colt.GetComponent<Animation>().Play();
            Instantiate(Resources.Load<GameObject>("SmokeEffect"), barrelEnd.transform.position, barrelEnd.transform.rotation);
            Source.PlayOneShot(GunNoise);
            //Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, barrelEnd.transform.position, barrelEnd.transform.rotation);
            //bulletClone.velocity = barrelEnd.transform.forward * bulletSpeed;
            RaycastHit hit;
            counter = 0;
            Flash = true;
            
            if (Physics.Raycast(transform.position, GunEnd.transform.forward, out hit))
            {
                hit.transform.SendMessage("HitByRay");
                Source.PlayOneShot(HitNoise);
                
            }
        }
	}

}