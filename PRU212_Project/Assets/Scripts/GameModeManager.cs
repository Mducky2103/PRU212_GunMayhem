using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameModeManager : MonoBehaviour
{
    [Header("UI Components")]
    public TextMeshProUGUI modeNameText;
    public TextMeshProUGUI descriptionText;
    public TMP_InputField livesInput;


    [Header("References")]
    public UIController uiController;

    [Header("Internal State")]
    private string selectedMode = "Last Man Standing";
    private int lives = 10;

    void Start()
    {
        SelectGameMode("Last Man Standing");
    }

    public void SelectGameMode(string mode)
    {
        selectedMode = mode;

        switch (mode)
        {
            case "Last Man Standing":
                modeNameText.text = "LAST MAN STANDING";
                descriptionText.text = "Players fight until only one remains.";
                break;

            case "1 Hit 1 Kill":
                modeNameText.text = "1 HIT 1 KILL";
                descriptionText.text = "Instant death on any hit.";
                break;

            case "Gun Game":
                modeNameText.text = "GUN GAME";
                descriptionText.text = "Progress weapons per kill. (In Development)";
                break;
        }
    }

    public void OnClickContinue()
    {
        if (int.TryParse(livesInput.text, out lives))
        {
            PlayerPrefs.SetString("SelectedMode", selectedMode);
            PlayerPrefs.SetInt("Lives", lives);

            // Move to map selection panel
            if (uiController != null)
                uiController.GoToMapSelection();
        }
        else
        {
            Debug.LogWarning("Invalid number of lives entered.");
        }
    }

    public void OnClickBack()
    {
        // Return to main menu
        if (uiController != null)
            uiController.ShowMainMenu();
    }
}
