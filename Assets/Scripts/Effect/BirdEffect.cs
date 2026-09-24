using System;
using Unity.VisualScripting;
using UnityEngine;

public class BirdEffect : Effect
{
   
    void Awake()
    {
        lifetime = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        transform.position += (Vector3.up) * Time.deltaTime * 2.0f;
        if( lifetime < 0.3) 
        {
            GetComponentInChildren<ParticleSystem>().Play();
        }
        if (lifetime < 0)
        {
            Destroy(this.gameObject);
        }
    }


}


