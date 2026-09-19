using UnityEngine;

public class AreaEffector : MonoBehaviour
{
    float lifetime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        if( lifetime > 10.0) 
        {
            Destroy(this);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        GameObject object_entered = other.gameObject;
        if (!object_entered.GetComponent<LevitateEffect>() || !object_entered.GetComponent<Rigidbody>())
        {
            object_entered.AddComponent<LevitateEffect>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject object_exit = other.gameObject;
        if (object_exit.GetComponent<LevitateEffect>() && object_exit.GetComponent<Rigidbody>())
        {
            Destroy(object_exit.GetComponent<LevitateEffect>());
        }
    }
}
