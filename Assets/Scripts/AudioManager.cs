using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Rotate rotate;
    AudioSource song;
    void Start()
    {
        rotate = GetComponent<Rotate>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
