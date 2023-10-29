using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicmanager : MonoBehaviour
{
    public AudioSource ASmusic;
    public AudioSource ASsound;
    public AudioClip menumusic;
    public AudioClip soundclickbutton;
    public AudioClip soundRight;
    public AudioClip soundwrong;

    // Start is called before the first frame update
    void Start()
    {
        // ASmusic.clip = menumusic;
        //ASmusic.PlayOneShot(menumusic);
        //ASmusic.Play();
    }

   public void Clickbutton()
    {
        ASsound.PlayOneShot(soundRight);
        Debug.Log("ok");
    }
    public void ClickWrongbutton()
    {
        ASsound.PlayOneShot(soundwrong);
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
