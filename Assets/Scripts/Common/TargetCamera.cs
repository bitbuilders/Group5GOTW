using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamera : MonoBehaviour
{
    [SerializeField] [Range(1.0f, 10.0f)] float m_distance;
    [SerializeField] [Range(1.0f, 20.0f)] float m_upOffset = 1.0f;
    [SerializeField] [Range(1.0f, 30.0f)] float m_lookSpeed = 1.0f;
    [SerializeField] [Range(1.0f, 90.0f)] float m_pitch = 1.0f;
    [SerializeField] [Range(0.1f, 10.0f)] float m_response = 1.0f;
    [SerializeField] GameObject m_target;

    float m_yaw = 0.0f;

    void Update()
    {
        m_yaw += Input.GetAxis("RightJoystickY") * m_lookSpeed;
        //m_pitch = Mathf.Clamp(m_pitch, m_pitchMin, m_pitchMax);

        Quaternion view = m_target.transform.rotation * Quaternion.Euler(m_pitch, m_yaw, 0.0f);
        Vector3 position = m_target.transform.position;
        Vector3 offset = (view * Vector3.back * m_distance) + Vector3.up * m_upOffset;

        Vector3 targetPosition = Vector3.Lerp(transform.position, position + offset, Time.deltaTime * m_response);
        Quaternion targetRotation = Quaternion.Lerp(transform.rotation, view, Time.deltaTime * m_response);
        transform.position = targetPosition;
        transform.rotation = targetRotation;
    }
}
