using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datamanager : MonoBehaviour
{
    // Start is called before the first frame update
    public float valuemusic;
    public float valuesound;
    public int maxscore;
    public bool isvibrate;
    private void Awake()
    {
        //Resetall();
        setupall();
    }
    void Start()
    {
        
    }

    public void setFvalue(string namevalue, float defaultvalue)
    {
       
       if (PlayerPrefs.GetString(namevalue)=="")
        {
            PlayerPrefs.SetString(namevalue, defaultvalue.ToString());
            Debug.Log(namevalue + " empty"+ PlayerPrefs.GetString(namevalue));
        }
       else
        {
            PlayerPrefs.SetString(namevalue, PlayerPrefs.GetString(namevalue));
            Debug.Log(namevalue + " unempty"+ PlayerPrefs.GetString(namevalue));
        }
    }

    public void setBvalue(string namevalue, bool defaultvalue)
    {

        if (PlayerPrefs.GetString(namevalue) == "")
        {
            PlayerPrefs.SetString(namevalue, defaultvalue.ToString());
            Debug.Log(namevalue + " empty" + PlayerPrefs.GetString(namevalue));
        }
        else
        {
            PlayerPrefs.SetString(namevalue, PlayerPrefs.GetString(namevalue));
            Debug.Log(namevalue + " unempty" + PlayerPrefs.GetString(namevalue));
        }
    }




    public void setIvalue(string name, int defaultvalue)
    {
        if (PlayerPrefs.GetString(name) =="")
        {
            PlayerPrefs.SetString(name, defaultvalue.ToString());
            Debug.Log(name + " empty");
        }
        else
        {
            PlayerPrefs.SetString(name, PlayerPrefs.GetString(name));
            Debug.Log(name + " unempty" + PlayerPrefs.GetString(name));
        }
    }


    public void setmusicvalue(float value)
    {
        PlayerPrefs.SetString("valuemusic", value.ToString());
        valuemusic = value;
    }

    public float getMusicvalue()
    {
        float a;
        a = float.Parse(PlayerPrefs.GetString("valuemusic"));
        return a;
    }
    public void setsoundvalue(float value)
    {
        PlayerPrefs.SetString("valuesound", value.ToString());
        valuesound = value;
    }



    public float getSoundvalue()
    {
        float a;
        a = float.Parse(PlayerPrefs.GetString("valuesound"));
        return a;
    }

    public void setMaxscore(int value)
    {
        PlayerPrefs.SetString("maxscore",value.ToString());
        maxscore = value;
    }

    public int getMaxscorevalue()
    {
        int a;
        a = int.Parse(PlayerPrefs.GetString("maxscore"));
        return a;
    }

    public void setvibrate(bool value)
    {
        PlayerPrefs.SetString("isvibrate", value.ToString());
        isvibrate = value;
    }

    public bool getvibrate()
    {
        bool a;
        a = bool.Parse(PlayerPrefs.GetString("isvibrate"));
        return a;
    }

    public void setupall()
    {
        setFvalue("valuemusic", 0.8f);
        valuemusic = getMusicvalue();

        setFvalue("valuesound", 0.8f);
        valuesound = getSoundvalue();

        setIvalue("maxscore", 0);
        maxscore = getMaxscorevalue();

        setBvalue("isvibrate", true);
        isvibrate = getvibrate();

    }
    public void Resetall()
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
