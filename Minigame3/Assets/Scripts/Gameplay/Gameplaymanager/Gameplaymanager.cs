using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class Gameplaymanager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float Timeend;
    [SerializeField] int Level;

    [SerializeField] public int result;
    [SerializeField] int FactorA;
    [SerializeField] int FactorB;
    [SerializeField] char Sign;
    [SerializeField] int Scope;
    [SerializeField] List<int> ListResult= new List<int>() ;
   // [SerializeField] List<string> listsign = new List<string>();

    [SerializeField] int Minimum;
    [SerializeField] int Maximum;

    [SerializeField] int amountButton;
    [SerializeField] GameObject ButtonObject;
    [SerializeField] GameObject ParentObject;
    [SerializeField] public List<GameObject> ListButton = new List<GameObject>();

    [SerializeField] public bool Isready;
    [SerializeField] public bool Isstart;
    [SerializeField] float MaxTime;
    [SerializeField] float CurrentTime;

    [SerializeField] public int currpoint;
    [SerializeField] public int Maxpoint;
    [SerializeField] public int templv;
    [SerializeField] public int limitMaximum;

    //UI
    [SerializeField] TextMeshProUGUI textCalculate;
    [SerializeField] Image imageTime;
    [SerializeField] GameObject Panelresult;
    [SerializeField] TextMeshProUGUI textCurrNumber;
    [SerializeField] TextMeshProUGUI textCurr;
    [SerializeField] TextMeshProUGUI textBest;
    void Start()
    {

        initbutton();
        Panelresult.transform.localScale = Vector3.zero;
        //setstartgame();
       
        this.gameObject.SetActive(false);
    }

    public void setstartgame()
    {
        Maxpoint = ManagerAll.instance.datamanager.getMaxscorevalue();
        CurrentTime = MaxTime;
        //initbutton();
        renewvalue();
        setsign();
        CalculateNumber(FactorA, FactorB, Sign);
        setresult();
        //Panelresult.transform.localScale = Vector3.zero;
    }



    public void setsign()
    {
        int a = Random.Range(0, ManagerAll.instance.listsign.Count);
        var b= ManagerAll.instance.listsign[a];
        Sign = b;

    }

    public void setnew()
    {
        levelmanager();
        setsign();
        renewvalue();
        CalculateNumber(FactorA, FactorB, Sign);
        setresult();
    }
    
    public void renewvalue()
    {
        int a = Random.Range(Minimum, Maximum);
        int b = Random.Range(Minimum, Maximum);
        if (a >= b)
        {
            FactorA = a; FactorB = b;
        }
        else 
        { 
            FactorA = b; FactorB = a;
        }
    }

    public void initbutton()
    {
        for(int i=0;i<amountButton;i++)
        {
           GameObject a = Instantiate(ButtonObject,
            ParentObject.transform.position,
            Quaternion.identity);
            a.SetActive(true);
           
            a.transform.SetParent(ParentObject.transform);
            a.transform.localScale = Vector3.one;
            ListButton.Add(a);
        }
    }


    public void setresult()
    {
        
            int []r = new int[amountButton-1];

        for(int j=0;j<amountButton-1;j++)
        {
            if (j%2 == 0) { r[j] = result + Random.Range(1, Scope);}
            else { r[j] = result - Random.Range(1, Scope); }
            ListResult.Add(r[j]);

        }
        
        ListResult.Add(result);
    
        for(int i=0;i<ListButton.Count;i++)
        {
            int ran = Random.Range(0, ListResult.Count);
            ListButton[i].GetComponent<ButtonParent>().setresult(ListResult[ran]);
            ListResult.RemoveAt(ran);
        }
    }

    public void calTime()
    {
        if (Isready)
        {
            if (Isstart)
            {
                imageTime.fillAmount = (CurrentTime / MaxTime);
                CurrentTime -= Time.deltaTime;
                if (CurrentTime <= 0)
                {
                    CurrentTime = 0;
                    ManagerAll.instance.musicmanager.ClickWrongbutton();
                    ManagerAll.instance.settingmanager.virabte();
                    setgameover();
                    showresult();
                    tweenpanelresult(Panelresult, Isstart);
                }
            }
        }
    }

    public void resettime()
    {
        CurrentTime = MaxTime;
        imageTime.fillAmount = (CurrentTime / MaxTime);
    }
    public void setgameover()
    {
        //Isstart = false;
        ManagerAll.instance.datamanager.setMaxscore(Maxpoint);
        Maxpoint = ManagerAll.instance.datamanager.getMaxscorevalue();
        settext(textCurr,"Current: ", currpoint);
        settext(textBest, "Best: ", Maxpoint);
        Isstart = false;
        
        tweenpanelresult(Panelresult, Isstart);
        
    }
    public void replay()
    {
        Isstart = true;      
        tweenpanelresult(Panelresult, Isstart);       
        
        Maximum -= templv;
       // if (Sign != '-')
        Minimum = 1;
        templv = 0;       
        showresult();
        resettime();
        setnew();
        currpoint = 0;
        settext(textCurrNumber, "", currpoint);
        settext(textCurr, "Current: ", currpoint);
        settext(textBest, "Best: ", Maxpoint);
        ManagerAll.instance.gameplaymanager.setiready(false);
    }

    public int CalculateNumber(int a,int b,char s)
    {
        int re=0;
        if(s=='+')
        {
            re = a + b;
        }
        else if (s == '-')
        {
            re = a - b;
        }
        else if (s == 'x')
        {
            re = a * b;
        }

        textCalculate.text = FactorA+" "+ Sign +" "+FactorB+" = ";
        result = re;
        return re;
    }

    public void tweenpanelresult(GameObject obj,bool IsEnd)
    {

        if (IsEnd == true)
        {
            Sequence twsequence = DOTween.Sequence();
            Tween a = obj.transform.DOScale(Vector3.zero, 0.3f);a.SetEase(Ease.Linear) ;
            Tween b = obj.GetComponent<Image>().DOFade(0, 0.3f);
            twsequence.Join(a);
            twsequence.Join(b);
            twsequence.Play();
            //a.Play(); 
        }
        else
        {
            Sequence twsequence = DOTween.Sequence();
            Tween a = obj.transform.DOScale(Vector3.one, 0.5f);
            a.SetEase(Ease.OutCirc);
            Tween b = obj.GetComponent<Image>().DOFade(0.80f, 0.3f);
            twsequence.Join(a);
            twsequence.Join(b);
            twsequence.Play();
        }
      
       
    }

    public void settext(TextMeshProUGUI textobj ,string describe,int value)
    {
        textobj.text = describe + value;
    }

    public void Addpoint()
    {
        currpoint ++;
        settext(textCurrNumber, "", currpoint);
        if(currpoint>Maxpoint)
        {
            Maxpoint = currpoint;
            //ManagerAll.instance.datamanager.setMaxscore(Maxpoint);
        }
    }
    public void setiready(bool isready)
    {
        Isready = isready;
    }

    public void levelmanager()
    {
        
        if(Isstart == true)
        {

            if (Maximum < limitMaximum)
            {
                Maximum += 2;
                if(Sign!='-')
                Minimum += 1;
                templv+=2;
            }
        }
    }
    public void showresult()
    {
        if (Isstart == false)
        {
            foreach (var item in ListButton)
            {
                if (item.GetComponent<ButtonParent>().result == result)
                {
                    item.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
                    tweentextresult(item.gameObject);
                }
                else item.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            }
        }
        else
        {
            foreach (var item in ListButton)
            {

                item.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            }
        }
    }

    public void tweentextresult(GameObject obj)
    {
        Sequence twsequence = DOTween.Sequence();
        Tween a = obj.transform.DOScale(new Vector3(1.3f, 1.3f, 0), 0.2f); a.SetEase(Ease.InBounce);
        Tween b = obj.transform.DOScale(Vector3.one, 0.2f); a.SetEase(Ease.Linear);
        twsequence.Append(a);
        twsequence.Append(b);
        twsequence.Play();

    }

    // Update is called once per frame
    void Update()
    {
        calTime();
    }
}
