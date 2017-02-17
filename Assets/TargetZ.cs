using UnityEngine;
using System.Collections;

public class TargetZ : MonoBehaviour
{
    private float respawnTime = 5;
    public GameObject player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            player = GameObject.Find("Camera (eye)");
            respawnTime -= Time.deltaTime;
            if (respawnTime < 0)
            {


                Vector3 targetPostition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                transform.LookAt(targetPostition);

            }


    }
}
