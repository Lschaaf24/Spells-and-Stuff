using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Kick : MonoBehaviour
{
    [SerializeField] private float kickRange = 20.0f;

    [SerializeField] private GameObject textUI;
    [SerializeField] private LayerMask kickableLayer;

    [SerializeField] private float power = 20.0f;

    private GameObject kickObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, kickRange, kickableLayer))
        {
            textUI.SetActive(true);
            kickObject = hit.collider.gameObject;
        }
        else
        {
            textUI.SetActive(false);
            kickObject = null;
        }
    }

    public void OnKick(InputValue value)
    {
        if (kickObject == null) return;

        kickObject.GetComponent<NavMeshAgent>().enabled = false;

        Vector3 displacement = kickObject.transform.position - transform.position;
        displacement.y =  2;
        displacement = displacement.normalized;

        kickObject.GetComponent<Rigidbody>().isKinematic = false;
        kickObject.GetComponent<Rigidbody>().AddForce(displacement * power, ForceMode.Impulse);

        
        kickObject.GetComponent<FollowPlayer>().BeginDemise();


    }
}
