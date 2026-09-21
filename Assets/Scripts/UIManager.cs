using Unity.VisualScripting;
using UnityEngine;

enum UIState
{
    interact,
    book,
    pause,
    play
}



public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject interactUI;
    [SerializeField] private GameObject bookUI;
    [SerializeField] private GameObject pauseGameUI;

    private UIState currentState;

    void Update()
    {
        switch (currentState)
        {
            case UIState.interact:
                break;

            case UIState.book: 
                break;

            case UIState.pause:
                break;

            case UIState.play:
                break;

        }
    }
}
