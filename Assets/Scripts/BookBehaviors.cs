using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BookBehaviors : MonoBehaviour
{
    [SerializeField] private BookContents bookContents;
    [SerializeField] private GameObject bookText;

    private TextMeshPro bText;

    private void Start()
    {
        bText = bookText.GetComponent<TextMeshPro>();
    }

    public void OpenBook()
    {
        bookText.SetActive(true);
        bText.text = bookContents.paragraphText;
    }
}
