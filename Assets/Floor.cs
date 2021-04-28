using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private float score;
    private void Start()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Box"))
        {
            score++;
            scoreText.text = "Скинуто: " + score;
            Destroy(collider.gameObject);
        }
    }
   
}
