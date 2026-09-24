using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Image book_outline;
    [SerializeField] TextMeshProUGUI play_text;
    [SerializeField] Image lever_outline;
    [SerializeField] TextMeshProUGUI quit_text;
    public void PlayButton() 
    {
        SceneManager.LoadScene("Level scne");
    }

    public void PlaySelect()
    {
        play_text.enabled = true;
        book_outline.color = Color.white;
    }

    public void PlayDeSelect()
    {
        play_text.enabled = false;
        book_outline.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    }
    public void QuitButton()
    {
        Application.Quit();
    }



    public void QuitSelect()
    {
        quit_text.enabled = true;
        lever_outline.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }


    public void QuitDeSelect() 
    {
        quit_text.enabled = false;
        lever_outline.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }
}
