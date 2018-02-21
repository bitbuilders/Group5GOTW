using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] [Range(1.0f, 100.0f)] float m_speed = 1.0f;
    [SerializeField] [Range(1.0f, 100.0f)] float m_turnSpeed = 1.0f;

    void Start()
    {

    }

    void Update()
    {
        Vector3 velocity = Vector3.zero;
        Vector3 rotate = Vector3.zero;

        velocity.z = Input.GetAxis("Vertical") * m_speed;
        rotate.y = Input.GetAxis("Horizontal") * m_turnSpeed;

        transform.rotation = transform.rotation * Quaternion.Euler(rotate * Time.deltaTime);

        transform.position += ((transform.rotation * velocity) * Time.deltaTime);
    }
}
