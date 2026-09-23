using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]private GameObject customerRoot;
    [SerializeField] private string[] dialogueLines;
    [SerializeField] private string[] winDialogueLines;
    [SerializeField] private string[] loseDialogueLines;
    [SerializeField] private ParticleSystem poof;
    public string[] DialogueLines => dialogueLines;
    public string[] WinDialogueLines => winDialogueLines;
    public string[] LoseDialogueLines => loseDialogueLines;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // poof.Play();
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
