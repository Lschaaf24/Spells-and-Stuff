using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] private CustomerData[] customers;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private bool CHECKER;
    
    private Customer currentCustomer;
    public Customer CurrentCustomer => currentCustomer;
    private string customerWinCondition;

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

        customerWinCondition = data.Spell;
        currentCustomer = Instantiate(data.prefab,spawnPoint).GetComponent<Customer>();

        Debug.Log(customerWinCondition);

        

    }

    // Update is called once per frame
    void Update()
    {
        checkSpell();
    }

    public void checkSpell()
    {
          if (currentCustomer.GetComponent<Effect>() != null)
          {

              Debug.Log("SPELL ON CUSTOMER CAST");
              if(currentCustomer.GetComponent<Effect>().GetEffectType() == customerWinCondition)
              {
                  Debug.Log("WIN");
              }

                if (CHECKER)
                {
                    currentCustomer.GetComponent<CustomerInteraction>().StartWinCustomerDialogue(currentCustomer);
                    CHECKER = false;
                }


          }



    }

}
