using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGmanagefloor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<RPGFloor> ListFloor = new List<RPGFloor>();
    [SerializeField] RPGFloor Floor;
    public int Floorquanity;
    void Start()
    {
        createFloor();
    }

    public void createFloor()
    {
        for(int i=0;i<Floorquanity;i++)
        {
            GameObject a = Instantiate(Floor.gameObject);
            a.transform.SetParent(this.gameObject.transform);
            a.GetComponent<RPGFloor>().initBattlefloor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
