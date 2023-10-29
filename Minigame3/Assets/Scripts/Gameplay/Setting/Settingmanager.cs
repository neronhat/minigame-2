using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Settingmanager : MonoBehaviour
{

    public bool isVibration;
    // Start is called before the first frame update
    public TextMeshProUGUI textvibrate;

    public Slider slidermusic;
    public Slider slidersound;
    public float currsound;
    public float currmusic;


    void Start()
    {
        setup();
    }
    public void virabte()
    {
        if (isVibration)
        {
            Handheld.Vibrate();
        }
    }

    public void changevibration()
    {
        
        if(isVibration)
        {
            isVibration = false;
            ManagerAll.instance.datamanager.setvibrate(isVibration);
            textvibrate.text = "Vibrate: OFF";
        }
        else
        {
            isVibration = true;
            ManagerAll.instance.datamanager.setvibrate(isVibration);
            textvibrate.text = "Vibrate: ON";
            virabte();
        }
        
    }

    public void setvaluemusic()
    {
        currmusic = slidermusic.value;
        slidermusic.value = currmusic / 1;
        ManagerAll.instance.musicmanager.ASmusic.volume = slidermusic.value;
    }
    public void setvaluesound()
    {
        currsound = slidersound.value;
        slidersound.value = currsound / 1;
        ManagerAll.instance.musicmanager.ASsound.volume = slidersound.value;
    }
   

    public void save()
    {
       
        ManagerAll.instance.datamanager.setmusicvalue(currmusic);
        ManagerAll.instance.datamanager.setsoundvalue(currsound);
        ManagerAll.instance.datamanager.setvibrate(isVibration);
       // ManagerAll.instance.datamanager.setMaxscore(currsound);
    }
    public void setup()
    {
        currsound = ManagerAll.instance.datamanager.getSoundvalue();

        slidersound.value = currsound;
        slidersound.value = currsound / 1;

        currmusic = ManagerAll.instance.datamanager.getMusicvalue();

        slidermusic.value = currmusic;
        slidermusic.value = currmusic / 1;

        ManagerAll.instance.musicmanager.ASmusic.volume = slidermusic.value;
        ManagerAll.instance.musicmanager.ASsound.volume = slidersound.value;

        isVibration = ManagerAll.instance.datamanager.getvibrate();
        if (isVibration) textvibrate.text = "Vibrate: ON";
        else textvibrate.text = "Vibrate: OFF";

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
