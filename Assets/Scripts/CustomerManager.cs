using UnityEngine;
using UnityEngine.InputSystem;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] private CustomerData[] customers;
    [SerializeField] private Transform spawnPoint;
    
    private Customer currentCustomer;
    public Customer CurrentCustomer => currentCustomer;

    void Start()
    {
        SpawnCustomer();
    }

    private void SpawnCustomer()
    {

        if(currentCustomer != null)
        {
            Destroy(currentCustomer);
        }
        
        CustomerData data = customers[Random.Range(0,customers.Length)];


        currentCustomer = Instantiate(data.prefab,spawnPoint).GetComponent<Customer>();

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
