using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using elementsystem;

public class RPGenemyparrent : MonoBehaviour
{
    // Start is called before the first frame update
    public float HPmax;
    public float Dmg;
   public element ResElement;
   public element MainElement;
    void Start()
    {
        //calele();
    }

    public void calele()
    {
      Dmg=elementsystem.Element.logicelement(MainElement,ResElement);
    }
    

    // Update is called once per frame
    void Update()
    {
        calele();
    }
}
