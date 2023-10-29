using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using DG.Tweening;

public class ButtonParent : MonoBehaviour
{
    

    [SerializeField] public int result;
    [SerializeField] TextMeshProUGUI textresult;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClickPick);
    }

    public void setresult(int a)
    {
        textresult.text = a.ToString();
        result = a;
    }
    public void OnClickPick()
    {
        ManagerAll.instance.gameplaymanager.setiready(true);
        if (ManagerAll.instance.gameplaymanager.Isstart)
        {  
            if (result == ManagerAll.instance.gameplaymanager.result)
            {
                ManagerAll.instance.musicmanager.Clickbutton();
                ManagerAll.instance.gameplaymanager.setnew();
                ManagerAll.instance.gameplaymanager.resettime();
                ManagerAll.instance.gameplaymanager.Addpoint();
            }
            else
            {
                ManagerAll.instance.musicmanager.ClickWrongbutton();
                ManagerAll.instance.settingmanager.virabte();
                ManagerAll.instance.gameplaymanager.setgameover();
                ManagerAll.instance.gameplaymanager.showresult();
            }
        }
    }

   

        // Update is called once per frame
        void Update()
    {
        
    }
}
