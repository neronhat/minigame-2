using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class PanelUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject childpanel;
    public bool iscanclick;
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(setunactivepanel);

        this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r
            , this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b,
            0);
        childpanel.transform.localScale=Vector3.zero;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tweenfadepanel(GameObject obj,float rate)
    { 
        Tween a = obj.GetComponent<Image>().DOFade(rate,0.5f);
       
        a.Play();
    }

    public void setunactivepanel()
    {
        if (iscanclick == false)
        {
            ManagerAll.instance.settingmanager.save();
            tweenfadepanel(this.gameObject, 0);
            tweenclosepanel(childpanel);
            Invoke("unactivepanel", 0.7f);
            iscanclick = true;

        }
    }

    public void setactivepanel()
    {
        if (iscanclick == true)
        {
            this.gameObject.SetActive(true);
            tweenfadepanel(this.gameObject, 0.7f);
            tweenopenpanel(childpanel);
            Invoke("activepanel", 0.7f);

        }
    }


    public void unactivepanel()
    {
        //iscanclick = true;
        this.gameObject.SetActive(false);
        
    }

    public void activepanel()
    {
       
        iscanclick = false;
    }


    public void tweenopenpanel(GameObject obj)
    {
       // Sequence twsequence = DOTween.Sequence();
        Tween a = obj.transform.DOScale(new Vector3(1f, 1f, 1), 0.75f); a.SetEase(Ease.OutBounce);
       // Tween b = obj.transform.DOScale(Vector3.one, 0.2f); a.SetEase(Ease.Linear);
        // twsequence.Append(a);
        //  twsequence.Append(b);
        // twsequence.Play();
        a.Play();

    }

    public void tweenclosepanel(GameObject obj)
    {
        // Sequence twsequence = DOTween.Sequence();
        Tween a = obj.transform.DOScale(new Vector3(0f, 0f, 0), 0.2f);
        // Tween b = obj.transform.DOScale(Vector3.one, 0.2f); a.SetEase(Ease.Linear);
        // twsequence.Append(a);
        //  twsequence.Append(b);
        // twsequence.Play();
        a.Play();

    }

    public void settimeactivepanel()
    {

    }


}
