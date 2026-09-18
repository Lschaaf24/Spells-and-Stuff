using UnityEngine;

public class LevitateEffect : MonoBehaviour 
{
    
    float lifetime = 0;
    private void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().AddForce(transform.up * 30, ForceMode.Force);       
    }
    private void Update()
    {
        lifetime += Time.deltaTime;
        if( lifetime > 10.0) 
        {
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
}




