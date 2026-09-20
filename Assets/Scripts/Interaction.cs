
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [SerializeField] private float interactionRange = 20.0f;
    [SerializeField] private GameObject textUI;
    [SerializeField] private LayerMask interactableLayer;

    private GameObject interactedObject;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange, interactableLayer))
        {
            textUI.SetActive(true);
            interactedObject = hit.collider.gameObject;

        }else
        {
            textUI.SetActive(false);
            interactedObject = null;
        }
    }

    public void OnInteract(InputValue value)
    {
        if (interactedObject == null) return;

        Debug.Log("Interacted with: " + interactedObject.name);

        if (interactedObject.CompareTag("Book"))
        {
            BookBehaviors book = interactedObject.GetComponent<BookBehaviors>();
            book.BookInteraction();
        }

        if (interactedObject.CompareTag("Customer")){
            Debug.Log("Interacted with customer");


            CustomerInteraction customer = interactedObject.GetComponent<CustomerInteraction>();
            customer.Interact(interactedObject);
        }
    }
}
