using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    public Vector3 direction = Vector3.forward;
    public Type effect_type;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent(effect_type)) 
        {
            other.gameObject.AddComponent(effect_type);
        }
        Destroy(gameObject);
    }
}
