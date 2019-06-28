using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScaler : MonoBehaviour
{
    //final pos 400, 950
    //scale 100
    private float scale;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.localScale = new Vector3(scale, scale, 1);
       // transform.position = new Vector3(PosX,PosY,0);
    }
}
