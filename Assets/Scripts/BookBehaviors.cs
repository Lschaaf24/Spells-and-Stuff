using StarterAssets;
using TMPro;
using UnityEngine;

public class BookBehaviors : MonoBehaviour
{
    [SerializeField] private BookContents bookContents;
    [SerializeField] private GameObject book;
    [SerializeField] private FirstPersonController playerController;

    private TextMeshProUGUI bText;


    private void Start()
    {
        bText = book.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void BookInteraction()
    {
        if (book.activeSelf)
        {
            CloseBook();
        }
        else
        {
            OpenBook();
        }   
    }

    private void OpenBook()
    {
        Debug.Log("Book opened: " + bookContents.paragraphText);
        book.SetActive(true);
        playerController.enabled = false;

        bText.text = bookContents.paragraphText;


        Cursor.lockState = CursorLockMode.None;
    }

    private void CloseBook()
    {
        Debug.Log("Book closed");
        Cursor.lockState = CursorLockMode.Locked;
        book.SetActive(false);
        playerController.enabled = true;
    }

}
