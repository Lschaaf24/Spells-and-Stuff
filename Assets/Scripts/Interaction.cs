using Unity.VisualScripting;
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
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
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

    public void interact(InputAction.CallbackContext callbackContext)
    {
        if (interactedObject == null) return;

        if (interactedObject.tag == "book")
        {
            BookBehaviors book = interactedObject.GetComponent<BookBehaviors>();
            book.OpenBook();
        }
    }
}
