using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapSelectionController : MonoBehaviour
{
    public Image previewImage;
    public Sprite defaultPreview; 

    private string selectedMap = "Random";

    void Start()
    {
        previewImage.sprite = defaultPreview;
    }

    public void SelectMap(string mapName)
    {
        selectedMap = mapName;
        Debug.Log("Map selected: " + selectedMap);

        if (mapName == "Random")
        {
            previewImage.sprite = defaultPreview;
        }
        else
        {
            Sprite mapPreview = Resources.Load<Sprite>("MapPreviews/" + mapName);
            if (mapPreview != null)
            {
                previewImage.sprite = mapPreview;
            }
            else
            {
                Debug.LogWarning("Not Found: " + mapName);
                previewImage.sprite = defaultPreview;
            }
        }
    }

    public void OnClickContinue()
    {
        PlayerPrefs.SetString("SelectedMap", selectedMap);
        Debug.Log("Saved map: " + selectedMap);

        SceneManager.LoadScene("GameScene");
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("GameSetupScene");
    }
}
