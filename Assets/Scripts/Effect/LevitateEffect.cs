using UnityEngine;

public class LevitateEffect : MonoBehaviour 
{
    
    float lifetime = 0;
    [SerializeField] float force = 60;
    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(Vector3.up * force, ForceMode.Force);

        Vector3 randomRotation = new Vector3(Random.Range(0.2f, 0.5f), Random.Range(0.2f, 0.5f), Random.Range(0.2f, 0.5f));
        rb.AddRelativeTorque(randomRotation, ForceMode.Impulse);

    }
    private void Update()
    {
        //lifetime += Time.deltaTime;
        //if( lifetime > 10.0) 
        //{
        //    Destroy(this);
        //}
    }

    private void OnDestroy()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
}




