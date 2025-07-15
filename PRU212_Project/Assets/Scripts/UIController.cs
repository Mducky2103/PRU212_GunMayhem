using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject gameModePanel;
    public GameObject mapSelectionPanel;

    void Start()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        gameModePanel.SetActive(false);
        mapSelectionPanel.SetActive(false);
    }

    public void GoToGameMode()
    {
        mainMenuPanel.SetActive(false);
        gameModePanel.SetActive(true);
        mapSelectionPanel.SetActive(false);
    }

    public void GoToMapSelection()
    {
        mainMenuPanel.SetActive(false);
        gameModePanel.SetActive(false);
        mapSelectionPanel.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit(); 
        Debug.Log("Exit Game"); 
    }
}
