using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 20.0f)] float m_maxLife = 3.0f;
    [SerializeField] [Range(0.1f, 20.0f)] float m_respawnTime = 3.0f;
    [SerializeField] GameObject m_cropHUD;

    ParticleSystem m_particleSystem;
    SphereCollider m_collider;
    MeshRenderer m_meshRenderer;
    TextMeshProUGUI m_hudText;
    float m_life;
    float m_time;

    bool Eaten { get { return m_life <= 0.0f; } }

    private void Start()
    {
        m_collider = GetComponent<SphereCollider>();
        m_meshRenderer = GetComponentInChildren<MeshRenderer>();
        m_particleSystem = GetComponentInChildren<ParticleSystem>();
        m_hudText = m_cropHUD.GetComponentInChildren<TextMeshProUGUI>();

        m_life = m_maxLife;
        m_time = 0.0f;
    }

    private void Update()
    {
        if (Eaten)
        {
            m_time += Time.deltaTime;
            if (m_time >= m_respawnTime)
            {
                Respawn();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Player player = other.GetComponent<Player>();
        if (other.CompareTag("Player") && !Eaten /*&& player.Alive*/)
        {
            if (Input.GetButton("Eat"))
            {
                NibbleOnCrop();
            }
            if (Input.GetButtonUp("Eat"))
            {
                m_life = m_maxLife;
            }
            m_cropHUD.SetActive(true);

            Vector3 direction = other.transform.position - transform.position;
            direction.x = 0.0f;
            direction.z = 0.0f;
            m_hudText.transform.LookAt(other.transform.position + Vector3.up * 3 - direction);
            m_hudText.transform.Rotate(0.0f, 180.0f, 0.0f);
        }

        if (Eaten)
        {
            m_cropHUD.SetActive(false);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_life = m_maxLife;

            m_cropHUD.SetActive(false);
        }
    }

    void NibbleOnCrop()
    {
        m_life -= Time.deltaTime;
        if (Eaten)
        {
            Die();
        }
        else
        {
            m_particleSystem.Play();
        }
    }

    void Die()
    {
        m_collider.enabled = false;
        m_meshRenderer.enabled = false;
        m_cropHUD.SetActive(false);
    }

    void Respawn()
    {
        m_time = 0.0f;
        m_life = m_maxLife;
        m_collider.enabled = true;
        m_meshRenderer.enabled = true;
    }
}
