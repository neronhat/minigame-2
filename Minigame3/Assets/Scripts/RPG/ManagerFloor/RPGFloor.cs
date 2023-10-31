using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGFloor : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> ListEnemies=new List<GameObject>();
    public List<GameObject> ListBosses=new List<GameObject>();
    public int rewardMoney;

    void Start()
    {
        
    }

    public void initBattlefloor()
    {
        Debug.Log("battle");
    }
    public void initMysteriFloor()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
