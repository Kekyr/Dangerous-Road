using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private VanMovement vanMovement;

    private void Start()
    {
        vanMovement = FindObjectOfType<VanMovement>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Van"))
        {
            Time.timeScale = 0;
        }
    }
}
