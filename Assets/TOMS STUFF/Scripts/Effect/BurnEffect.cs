using System;
using UnityEngine;

public class BurnEffect : MonoBehaviour
{
    [SerializeField] float lifetime = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MaterialPropertyBlock props = new MaterialPropertyBlock();
        props.SetColor("_BaseColor", Color.red);
        GetComponent<MeshRenderer>().SetPropertyBlock(props);
       
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime < 0) 
        {
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        MaterialPropertyBlock props = new MaterialPropertyBlock();
        props.SetColor("_BaseColor", Color.black);
        GetComponent<MeshRenderer>().SetPropertyBlock(props);
    }
}
