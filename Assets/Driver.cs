using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]float steerspeed = 300f;
    [SerializeField]float movespeed = 20f;
    

    void Update()
    {
        float steeramount = Input.GetAxis("Horizontal")*steerspeed*Time.deltaTime;
        float moveamount = Input.GetAxis("Vertical")*movespeed*Time.deltaTime;        
        transform.Rotate(0,0,-steeramount);
        transform.Translate(0,moveamount,0);
    }
}
