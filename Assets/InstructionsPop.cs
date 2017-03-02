using UnityEngine;
using UnityEditor;
using System.Collections;

public class InstructionsPop : MonoBehaviour {
    public GameObject playerBro;
    public GameObject CowDude;
    Vector3 destination = new Vector3(90, 0, 0);
    private bool falling;
    public GameObject gun;

    public GameObject Civillian;
    public float deathRotaion;                
    public float roationSmoothness;
    public float appearenceScore = 0;
    public float zRot;
                         
    private bool doDestroyLogic = true;
    private float choice;
    private float respawnModifier;               
    private float respawnTime;
    private float respawnModiferHome;
    private float scoreHome;
    public AudioClip Pop;
    public AudioClip Bell;
    private AudioSource SoundSource;
    private bool soundTrigger = false;
    public bool isStarter = false;
    // Use this for initialization
    void Start () {
     
        respawnModifier = 5;
        respawnModiferHome = GameControl.respawnFloat;
        zRot = this.transform.rotation.eulerAngles.z;
        falling = false;
        SoundSource = GetComponent<AudioSource>();
        ;
    }

    // Update is called once per frame
    void Update()
    {         
        if (GameControl.Score >= appearenceScore)
        {
            if (player.shot)
            {
                falling = true;
            }
            
            
            respawnModiferHome -= Time.deltaTime;
            playerBro = GameObject.Find("Camera (eye)");
            if (respawnModiferHome < 0)
            {
                    Vector3 targetPostition = new Vector3(playerBro.transform.position.x, this.transform.position.y, playerBro.transform.position.z);
                    transform.LookAt(targetPostition);
            }
        }
    }
}
