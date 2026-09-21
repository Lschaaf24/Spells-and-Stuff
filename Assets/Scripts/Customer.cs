using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]private GameObject customerRoot;
    [SerializeField] private string[] dialogueLines;

    public string[] DialogueLines => dialogueLines;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getRoot()
    {
        return customerRoot;
    }






}
