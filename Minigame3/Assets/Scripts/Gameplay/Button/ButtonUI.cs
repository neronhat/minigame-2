using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ButtonUI : MonoBehaviour,
    ISelectHandler,IDeselectHandler,
    IPointerEnterHandler,IPointerExitHandler,
    IPointerDownHandler,IPointerUpHandler
{
   public bool ismode;
    public bool ison;
    // Start is called before the first frame update
    void Start()
    {
        //  this.GetComponent<Button>().onClick.AddListener(tweenButton);

       
    }

    public void opencontact()
    {
        Application.OpenURL("https://www.facebook.com/neronhat123/");
    }

    public void openchplay()
    {
        Application.OpenURL("https://play.google.com/store/apps/developer?id=Nero+solaire&hl=en");
    }


    public void restartgame()
    {
        ManagerAll.instance.gameplaymanager.replay();
    }

    public void gobackMenu()
    {
        ManagerAll.instance.gameplaymanager.replay();
       ManagerAll.instance.musicmanager.Clickbutton();
        ManagerAll.instance.exitgameplay();
    }
    public void opengameplay()
    {
        ManagerAll.instance.musicmanager.Clickbutton();
        ManagerAll.instance.opengameplay();
        ManagerAll.instance.gameplaymanager.setstartgame();
        ManagerAll.instance.panelmode.setunactivepanel();
    }
    public void onclickvirabtion()
    {
        ManagerAll.instance.settingmanager.changevibration();
    }


    public void tweenButton()
    {    
        Tween a = this.gameObject.transform.DOScale(new Vector3(0.75f,0.75f,0.75f), 0.1f);
            Tween b=this.gameObject.transform.DOScale(Vector3.one, 0.1f);
        Sequence tweensequence = DOTween.Sequence();
        tweensequence.Append(a);
        tweensequence.Append(b);
        tweensequence.Play(); 
    }

    public void openmodepanel()
    {
        ManagerAll.instance.musicmanager.Clickbutton();
        ManagerAll.instance.panelmode.setactivepanel();
            
    }

    public void opensettingpanel()
    {
        ManagerAll.instance.musicmanager.Clickbutton();
        ManagerAll.instance.panelsetting.setactivepanel();

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect(BaseEventData eventData)
    {
     
    }

    public void OnDeselect(BaseEventData eventData)
    {
      
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       
    }

    public void addsign(string sign)
    {
        char a = sign[0];
        ManagerAll.instance.musicmanager.Clickbutton();
        if (!ManagerAll.instance.listsign.Contains(a))
        {
            ManagerAll.instance.listsign.Add(a);
            // ManagerAll.instance.gameplaymanager.ListButton.
            
            ison = true;
            setcolormode();
        }
        else
        {
            if (ManagerAll.instance.listsign.Count > 1)
            {
                ison = false;
                setcolormode();
                ManagerAll.instance.listsign.Remove(a);
               
            }
           
        }
    }

    public void setcolormode()
    {
        if(ismode)
        {
            if(ison)
            {
                this.GetComponent<Image>().color = Color.white;
            }
            else this.GetComponent<Image>().color = Color.gray;
        }
    }


    public void addmixsign()
    {
        string a = "+-x";
        ManagerAll.instance.musicmanager.Clickbutton();
        for (int i=0;i<a.Length;i++)
        {       
            {
                if(!ManagerAll.instance.listsign.Contains(a[i]))
                {
                    ManagerAll.instance.listsign.Add(a[i]);
                    ManagerAll.instance.listbut[i].GetComponent<ButtonUI>().ison = true;
                   ManagerAll.instance.listbut[i].GetComponent<ButtonUI>().setcolormode();
                }
            }
        }      
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        //ManagerAll.instance.musicmanager.Clickbutton();
        Tween a = this.gameObject.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.1f);
        a.Play();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Tween b = this.gameObject.transform.DOScale(Vector3.one, 0.1f);
        b.Play();
    }
}
