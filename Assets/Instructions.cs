using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Instructions : MonoBehaviour
{
    public Text txt;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void HitByRay()
    {
        txt.enabled = !txt.enabled;
    }
}
