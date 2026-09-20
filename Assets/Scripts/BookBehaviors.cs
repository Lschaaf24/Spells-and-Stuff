using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BookBehaviors : MonoBehaviour
{
    [SerializeField] private BookContents bookContents;
    [SerializeField] private GameObject bookText;
    [SerializeField] private FirstPersonController playerController;

    private TextMeshProUGUI bText;

    private void Start()
    {
        bText = bookText.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void BookInteraction()
    {
        if (bookText.activeSelf)
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
        bookText.SetActive(true);
        playerController.enabled = false;
        bText.text = bookContents.paragraphText;
        Cursor.lockState = CursorLockMode.None;
    }

    private void CloseBook()
    {
        Debug.Log("Book closed");
        Cursor.lockState = CursorLockMode.Locked;
        bookText.SetActive(false);
        playerController.enabled = true;
    }
}
