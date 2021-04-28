using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField] private float swipeForce;
    [SerializeField] private float length;
    public float swipeRange;
    private float score;

    private TextMeshProUGUI scoreText;
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 Distance;
    private Rigidbody rigidBody;
    private Ray ray;
    private RaycastHit hit;

    private void Start()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>();
    }
    

    private void FixedUpdate()
    {
        Swipe();
    }

    private void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Physics.Raycast(ray, out hit, length);

            if (hit.collider != null && hit.collider.CompareTag("Box"))
            {
                rigidBody = hit.collider.gameObject.GetComponent<Rigidbody>();
                startTouchPosition = Input.GetTouch(0).position;
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            if (startTouchPosition != null)
            {
                Distance = currentPosition - startTouchPosition;
            }
        }

        if (Distance.x < -swipeRange)
        {
            rigidBody.AddForce(new Vector3(-swipeForce, 0, 0));
            Distance = Vector2.zero;
        }
        else if (Distance.x > swipeRange)
        {
            rigidBody.AddForce(new Vector3(swipeForce, 0, 0));
            Distance = Vector2.zero;
        }

    }
}


