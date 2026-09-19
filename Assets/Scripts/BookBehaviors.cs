using TMPro;
using UnityEngine;

public class BookBehaviors : MonoBehaviour
{
    [SerializeField] private BookContents bookContents;
    [SerializeField] private GameObject bookText;
    //[SerializeField] private FirstPersonController playerController;

    public void OpenBook()
    {
        Debug.Log("Book opened: " + bookContents.paragraphText);
        bookText.SetActive(true);
        //playerController.enabled = false;
        TextMeshProUGUI bText = bookText.GetComponentInChildren<TextMeshProUGUI>();
        bText.text = bookContents.paragraphText;
    }
}
