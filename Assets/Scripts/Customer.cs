using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEditor;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]private GameObject customerRoot;
    [SerializeField] private GameObject characterMeshes;
    [SerializeField] private List<Transform> meshes;
    [SerializeField] private string[] dialogueLines;
    [SerializeField] private string[] winDialogueLines;
    [SerializeField] private string[] loseDialogueLines;
    [SerializeField] private ParticleSystem poof;
    [SerializeField] private GameObject currentCharacterMesh;
    public string[] DialogueLines => dialogueLines;
    public string[] WinDialogueLines => winDialogueLines;
    public string[] LoseDialogueLines => loseDialogueLines;
    public GameObject CurrentCharacterMesh => currentCharacterMesh;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // poof.Play();
        
        
            foreach (Transform t in characterMeshes.transform)
            {
                if(name != "root")
                {
                    meshes.Add(t);
                }
            }
        

        int index = Random.Range(0, meshes.Count);

        meshes[index].gameObject.SetActive(true);
        currentCharacterMesh = meshes[index].gameObject;
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
