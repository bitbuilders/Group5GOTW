﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 20.0f)] float m_maxLife = 3.0f;
    [SerializeField] [Range(0.1f, 20.0f)] float m_respawnTime = 3.0f;
    [SerializeField] KeyCode m_eatKey = KeyCode.Space;

    ParticleSystem m_particleSystem;
    SphereCollider m_collider;
    MeshRenderer m_meshRenderer;
    float m_life;
    float m_time;

    bool Eaten { get { return m_life <= 0.0f; } }

    private void Start()
    {
        m_collider = GetComponent<SphereCollider>();
        m_meshRenderer = GetComponentInChildren<MeshRenderer>();
        m_particleSystem = GetComponentInChildren<ParticleSystem>();

        m_life = m_maxLife;
        m_time = 0.0f;
    }

    private void Update()
    {
        NibbleOnCrop();
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
        if (other.CompareTag("Player") /*&& player.Alive*/)
        {
            if (Input.GetKey(m_eatKey))
            {
                NibbleOnCrop();
            }
            if (Input.GetKeyUp(m_eatKey))
            {
                m_life = m_maxLife;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_life = m_maxLife;
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
    }

    void Respawn()
    {
        m_time = 0.0f;
        m_life = m_maxLife;
        m_collider.enabled = true;
        m_meshRenderer.enabled = true;
    }
}