using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ManagerAll : MonoBehaviour
{
    public static ManagerAll instance;
    public Gameplaymanager gameplaymanager;
    public GameObject gameplayObject;
    public GameObject paneltransferObject;
    public Image imagebg;
    public float speed;
    float x, y;
    public Settingmanager settingmanager;
    public List<char> listsign = new List<char>();
    public List<Button> listbut = new List<Button>();

    public PanelUI panelmode;
    public PanelUI panelsetting;

    public Datamanager datamanager;

    public Color[] listcolor =new Color[6];

    public Musicmanager musicmanager;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        paneltransferObject.transform.localScale = new Vector3(1f, 1, 1);
        paneltransferObject.transform.localPosition = new Vector3(-gameplayObject.GetComponent<RectTransform>().rect.width, 0,0);
       // listbut[0].GetComponent<ButtonUI>().addsign("+");
        for(int i=0;i<listbut.Count;i++)
        {
            if (i == 0) listbut[0].GetComponent<ButtonUI>().addsign("+");
            else
            {
                listbut[i].GetComponent<ButtonUI>().setcolormode();
            }
        }
    }

    public void opengameplay()
    {
        changecolor();
        tweenpaneltransfer();
        Invoke("setactive", 0.6f);
       // gameplayObject.SetActive(true);
    }

    public void setactive()
    {
        gameplayObject.SetActive(true);
        //gameplaymanager.setstartgame();
    }
    public void setunactive()
    {
        gameplayObject.SetActive(false);
    }

    public void exitgameplay()
    {
        tweenpaneltransfer();
        ManagerAll.instance.gameplaymanager.setiready(false);
        Invoke("setunactive", 0.6f);
    }
    public void tweenpaneltransfer()
    {
        Tween a = this.paneltransferObject.transform.DOLocalMoveX(0,0.5f);
        a.SetEase(Ease.OutExpo);
        Tween b = this.paneltransferObject.transform.DOLocalMoveX(-gameplayObject.GetComponent<RectTransform>().rect.width, 0.5f);
        b.SetEase(Ease.InExpo);
        Sequence tweensequence = DOTween.Sequence();
        tweensequence.Append(a);
        tweensequence.Append(b);
        tweensequence.Play();
    }

    public void loopbg()
    {
        x += Time.deltaTime*speed;
        y += Time.deltaTime*speed;
        imagebg.material.SetTextureOffset("_MainTex", new Vector2(x, y));
    }


    //public void openmodepanel()
    //{
    //    panelmode.tweenfadepanel(panelmode.gameObject,0.8f);
    //    panelmode.tweenopenpanel(panelmode.childpanel);
    //}

    public void changecolor()
    {
        paneltransferObject.GetComponent<Image>().color= listcolor[Random.Range(0, listcolor.Length - 1)];
    }



    // Update is called once per frame
    void Update()
    {
        loopbg();
    }
}
