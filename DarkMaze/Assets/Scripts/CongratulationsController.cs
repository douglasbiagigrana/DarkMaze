using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CongratulationsController : MonoBehaviour
{
    public TextMeshProUGUI congratulationText;

    void OnCollectedAllCollectables()
    {
        congratulationText.enabled = true;
    }

    private void Update()
    {
        if (!congratulationText.enabled)
        {
            return;
        }

        var color = Color.HSVToRGB(
            Time.realtimeSinceStartup % 1f,
            1,
            1
        );
        congratulationText.color = color;

    }

    void OnFire()
    {
        if (!congratulationText.enabled)
        {
            return;
        }

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name,
            LoadSceneMode.Single
        );
    }
}
