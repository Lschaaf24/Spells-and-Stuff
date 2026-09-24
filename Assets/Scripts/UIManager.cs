using StarterAssets;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public enum UIState
{
    book,
    pause,
    dialogue,
    spellCatalogue,
    play
}

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject bookUI;
    [SerializeField] private GameObject pauseGameUI;
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private GameObject spellCatalogueUI;
    [SerializeField] private GameObject wordUI;
    [SerializeField] private FirstPersonController firstPersonController;

    public UIState currentState = UIState.play;

    private void Awake()
    {
        instance = this;
        currentState = UIState.play;
    }

    void Update()
    {
        switch (currentState)
        {
            case UIState.book:
                bookUI.SetActive(true);
                wordUI.SetActive(false);
                firstPersonController.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                break;

            case UIState.pause:
                pauseGameUI.SetActive(true);
                wordUI.SetActive(false);
                firstPersonController.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                break;

            case UIState.dialogue:
                dialogueUI.SetActive(true);
                firstPersonController.enabled = false;
                Cursor.lockState = CursorLockMode.Locked;
                break;

            case UIState.spellCatalogue:
                spellCatalogueUI.SetActive(true);
                wordUI.SetActive(false);
                firstPersonController.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                break;

            case UIState.play:
                dialogueUI.SetActive(false);
                bookUI.SetActive(false);
                pauseGameUI.SetActive(false);
                spellCatalogueUI.SetActive(false);
                wordUI.SetActive(true);
                firstPersonController.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                break;

        }
    }

    public void setCurrentState(UIState state)
    {
        currentState = state;
    }
}
