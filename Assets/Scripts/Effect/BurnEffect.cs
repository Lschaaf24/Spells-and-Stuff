using System;
using UnityEngine;

public class BurnEffect : Effect
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        effect_type = "fire";
        MaterialPropertyBlock props = new MaterialPropertyBlock();
        props.SetColor("_Color", Color.red);
        
        if(tag == "Customer")
        {
                GetComponent<Customer>().CurrentCharacterMesh.GetComponent<SkinnedMeshRenderer>().SetPropertyBlock(props);
        }

        GetComponent<MeshRenderer>().SetPropertyBlock(props);
       
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime < 0) 
        {
            MaterialPropertyBlock props = new MaterialPropertyBlock();
            props.SetColor("_BaseColor", Color.black);
            if (tag == "Customer")
            {
                    GetComponent<Customer>().CurrentCharacterMesh.GetComponent<SkinnedMeshRenderer>().SetPropertyBlock(props);
            }
            GetComponent<MeshRenderer>().SetPropertyBlock(props);
        }
    }

}
