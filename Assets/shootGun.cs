using UnityEngine;
using System.Collections;
using Valve.VR;
public class shootGun : MonoBehaviour {
    private float WaitTime;
    public float FireRate = 0.1f;
    public AudioClip GunNoise;
    public AudioClip HitNoise;
    private AudioSource Source;
    public GameObject GunEnd;
    private SteamVR_TrackedObject device;
    private SteamVR_Controller.Device controller {  get { return SteamVR_Controller.Input((int)device.index);} }
    private bool trigger = false;
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private bool triggerButtonDown = false;
    private bool triggerButtonUp = false;
    private bool triggerButtonPressed = false;

    // Use this for initialization
    void Start () {
        Source = GetComponent<AudioSource>();
        device = GetComponent<SteamVR_TrackedObject>();

        
    }
	
	// Update is called once per frame
	void Update () {

        triggerButtonDown = controller.GetPressDown(triggerButton);
        triggerButtonUp = controller.GetPressUp(triggerButton);
        triggerButtonDown = controller.GetPress(triggerButton);
        Debug.DrawRay(transform.position, GunEnd.transform.forward, Color.green);
if (triggerButtonDown && Time.time > WaitTime)
        {
            SteamVR_Fade.Start(Color.black, 0);
            SteamVR_Fade.Start(Color.clear, 1);
            Source.PlayOneShot(GunNoise);
            WaitTime = Time.time + FireRate; //Firing Cooldown time
            RaycastHit hit;
            if (Physics.Raycast(transform.position, GunEnd.transform.forward, out hit))
            {
                Source.PlayOneShot(HitNoise);
                hit.transform.SendMessage("HitByRay");
            }

        }
        if (triggerButtonDown)
        {
            print("hello2");
        }
           
    }

}
