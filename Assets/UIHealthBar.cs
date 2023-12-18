using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public Image Healthbar;
    private Transform _player;
    private PlayerHealth _playerHealth;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        if (_player == null)
            return;

        _playerHealth = _player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (Healthbar == null) return;

        if (_playerHealth == null)
        {
            Healthbar.fillAmount = 0f;
            return;
        }

        float fillAmount = _playerHealth.health / (float)_playerHealth.maxHealth;
        Healthbar.fillAmount = fillAmount;
    }
}

