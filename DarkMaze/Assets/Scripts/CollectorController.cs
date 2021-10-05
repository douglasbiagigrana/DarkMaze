using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface IInteractable
{
    void OnCollected();
}

public class CollectorController : MonoBehaviour
{
    int score = 0;

    public TextMeshProUGUI scoreText;

    public Transform collectablesParent;

    public GameObject[] total;

    private void OnTriggerEnter(Collider other)
    {

        total = GameObject.FindGameObjectsWithTag("Collectable");
        

        if (other.CompareTag("Collectable"))
        {
            other.gameObject.SendMessage("OnCollected", SendMessageOptions.DontRequireReceiver);
            scoreText.text = (++score).ToString();

            if (total.Length <= 1)
            {
                SendMessage(
                    "OnCollectedAllCollectables",
                    SendMessageOptions.DontRequireReceiver
                );
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    }
}
