using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    /// <summary>
    /// Speed to rotate.
    /// </summary>
    [SerializeField] private float turnSpeed = 5;

    /// <summary>
    /// Movement.
    /// </summary>
    private Vector2 movement;

    void Update()
    {
        Vector2 currentPosition = transform.position;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 moveTowards = Camera.main.ScreenToWorldPoint(touch.position);

                movement = moveTowards - currentPosition;
                movement.Normalize();
            }
        }

        float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, 
                                              Quaternion.Euler(0, 0, targetAngle), 
                                              turnSpeed * Time.deltaTime);
    }
}
