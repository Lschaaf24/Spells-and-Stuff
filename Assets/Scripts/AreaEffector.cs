using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;


public class AreaEffector : MonoBehaviour
{
    float lifetime = 0;
    List<GameObject> effected_objects = new List<GameObject>();
    public Type effect_type;

    void Start()
    {
        
    }

    void Update()
    {
        lifetime += Time.deltaTime;
        if( lifetime > 5.0) 
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        GameObject object_entered = other.gameObject;
        
        if (!object_entered.GetComponent(effect_type) || !object_entered.GetComponent<Rigidbody>())
        {
            effected_objects.Add(object_entered);
            object_entered.AddComponent(effect_type);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject object_exit = other.gameObject;
        if (object_exit.GetComponent(effect_type) && object_exit.GetComponent<Rigidbody>())
        {
            effected_objects.Remove(object_exit);
            Destroy(object_exit.GetComponent(effect_type));
        }
    }

    private void OnDestroy()
    {
        foreach(GameObject obj in effected_objects) 
        {
            Destroy(obj.GetComponent(effect_type));
        }
    }
}
