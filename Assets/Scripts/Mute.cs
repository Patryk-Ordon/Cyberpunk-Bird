using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public Image image;
    public AudioSource song;
    public Sprite soundOn;
    public Sprite soundOff;

    // Start is called before the first frame update
    void Start()
    {
        //image = transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (song.mute)
        {
            song.mute = false;
            image.sprite = soundOn;
        }
        else
        {
            song.mute = true;
            image.sprite = soundOff;
        }
    }
}
