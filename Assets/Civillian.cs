using UnityEngine;
using System.Collections;

public class Civillian : MonoBehaviour
{
    public GameObject player;
    public GameObject Cowboy;
    Vector3 destination = new Vector3(90, 0, 0);
    private bool falling;
    public GameObject gun;
    public float deathRotaion;
    public float roationSmoothness;
    public float appearenceScore = 0;

    private bool doDestroyLogic = true;
    private float choice;
    private float respawnModifier;
    private float respawnTime;
    private float respawnModiferHome;
    private float scoreHome;
    public AudioClip Pop;
    private AudioSource SoundSource;
    private bool soundTrigger = false;
    public float downTime;
    private float startTime;
    // Use this for initialization
    void Start()
    {

        respawnModifier = 5;
        respawnModiferHome = GameControl.respawnFloat;
        falling = false;
        SoundSource = GetComponent<AudioSource>();
        startTime = downTime;
    }

    // Update is called once per frame
    void Update()
    {
        startTime -= Time.deltaTime;
        if (GameControl.Score >= appearenceScore)
        {



            respawnModiferHome -= Time.deltaTime;
            player = GameObject.Find("Camera (eye)");
            if (respawnModiferHome < 0)
            {
                SoundSource.PlayOneShot(Pop);
                Pop = null;
                if (falling)
                {
                    //falling animation
                    Quaternion target = Quaternion.Euler(deathRotaion, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
                    transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * roationSmoothness);
                    Destroy(gun);
                    if ((Mathf.Abs(transform.eulerAngles.x - deathRotaion) <= 10) && (doDestroyLogic = true))
                    {
                        doDestroyLogic = false;
                        choice = Random.Range(1, 3);
                        
                        if (choice < 2)
                        {
                            //spawn civillian
                            Instantiate(Resources.Load<GameObject>("Cowboy[]"), this.transform.position, Quaternion.Euler(90, this.transform.rotation.y, this.transform.rotation.z));
                            falling = false;
                            Destroy(this.gameObject);
                            
                        }
                        else
                        {
                            //spawning a target
                            Instantiate(Resources.Load<GameObject>("CopyCowboy"), this.transform.position, Quaternion.Euler(90, this.transform.rotation.y, this.transform.rotation.z));
                            falling = false;
                            Destroy(this.gameObject);
                        }
                    }



                }


                else
                {
                    Vector3 targetPostition = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
                    transform.LookAt(targetPostition);
                }

                if (startTime <= 0)
                {
                    falling = true;
                }
            }
        }
    }

    void HitByRay()
    {
        GameControl.Score--;
        falling = true;
        
    }

}
