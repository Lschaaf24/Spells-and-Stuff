
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [SerializeField] private float interactionRange = 20.0f;
    [SerializeField] private GameObject textUI;
    [SerializeField] private LayerMask interactableLayer;

    private GameObject interactedObject;

    [SerializeField] private Material outlineMaterial;

    private Renderer objectRenderer;

    private bool addedMaterial;
    private bool removedMaterial;


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange, interactableLayer))
        {
            textUI.SetActive(true);
            interactedObject = hit.collider.gameObject;
            AddOutlineMaterial();
        }
        else
        {
            textUI.SetActive(false);
            interactedObject = null;

            RemoveOutlineMaterial();
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

    public void OnPause(InputValue value)
    {
        Debug.Log("paused");
        if(UIManager.instance.currentState == UIState.pause)
        {
            UIManager.instance.setCurrentState(UIState.play);
        }
        else
        {
            UIManager.instance.setCurrentState(UIState.pause);
        }
    }

    public void OnOpenSpellbook(InputValue value)
    {
        if(UIManager.instance.currentState == UIState.spellCatalogue) 
        {
            UIManager.instance.setCurrentState(UIState.play);

        }
        else
        {
            UIManager.instance.setCurrentState(UIState.spellCatalogue);
        }
    }

    void AddOutlineMaterial()
    {
        if (addedMaterial) return;

        objectRenderer = interactedObject.GetComponent<Renderer>();

        Material[] materialArray = new Material[objectRenderer.materials.Length + 1];
        objectRenderer.materials.CopyTo(materialArray, 0);
        materialArray[materialArray.Length - 1] = outlineMaterial;
        objectRenderer.materials = materialArray;

        addedMaterial = true;
        removedMaterial = false;
    }

    void RemoveOutlineMaterial()
    {
        if (removedMaterial) return;
        if (objectRenderer == null) return;

        Material[] materialArray = new Material[objectRenderer.materials.Length - 1];
        for (int i = 0; i < materialArray.Length; i++)
        {
            materialArray[i] = objectRenderer.materials[i];
        }
        objectRenderer.materials = materialArray;

        removedMaterial = true;
        addedMaterial = false;
    }
}
