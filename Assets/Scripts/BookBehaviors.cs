using StarterAssets;
using TMPro;
using UnityEngine;

public class BookBehaviors : MonoBehaviour
{
    [SerializeField] private BookContents bookContents;
    [SerializeField] private GameObject book;

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

        UIManager.instance.setCurrentState(UIState.book);

        bText.text = bookContents.paragraphText;

    }

    private void CloseBook()
    {
        Debug.Log("Book closed");
        Cursor.lockState = CursorLockMode.Locked;

        UIManager.instance.setCurrentState(UIState.play);
    }

}
