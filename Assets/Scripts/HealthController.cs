﻿using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float Health;
    private Dictionary<string, GameObject> _hearts;
    public Texture HeartFullTexture;
    public Texture HeartEmptyTexture;

    void Start()
    {
        switch (this.tag)
        {
            case "Player":
                Health = GameProperties.PlayerMaxHealth;
                break;
            case "Enemies":
                Health = GameProperties.EnemyMaxHealth;
                break;
            case "finalboss":
                Health = GameProperties.EnemyMaxHealth;
                break;
        }
    }

    void Update()
    {
        if (Health <= 0.0f)
        {
            if (this.tag == "Player")
            {
                ResetGame();
            }

            Destroy(this.gameObject);
        }

        if (this.tag == "Player")
        {
            if (_hearts == null || _hearts.Count == 0)
            {
                _hearts = new Dictionary<string, GameObject>();

                // Add hearts to the dictionary for easier access
                var hudObjects = GameObject.FindGameObjectsWithTag("Hud");
                foreach (var hudObject in hudObjects)
                {
                    if (hudObject.name.StartsWith("Health_"))
                    {
                        _hearts.Add(hudObject.name, hudObject);
                    }
                }
            }

            if (Health >= 3.5f)
            {
                SetHeart(0, true);
                SetHeart(1, true);
                SetHeart(2, true);
                SetHeart(3, true);
            }
            else if (Health >= 2.5f)
            {
                SetHeart(0, true);
                SetHeart(1, true);
                SetHeart(2, true);
                SetHeart(3, false);
            }
            else if (Health >= 1.5f)
            {
                SetHeart(0, true);
                SetHeart(1, true);
                SetHeart(2, false);
                SetHeart(3, false);
            }
            else if (Health >= 0.5f)
            {
                SetHeart(0, true);
                SetHeart(1, false);
                SetHeart(2, false);
                SetHeart(3, false);
            }
            else
            {
                SetHeart(0, false);
                SetHeart(1, false);
                SetHeart(2, false);
                SetHeart(3, false);
            }
        }
    }

    private void SetHeart(int heartNumber, bool isFull)
    {
        _hearts["Health_" + heartNumber].GetComponent<GUITexture>().texture = isFull ? HeartFullTexture : HeartEmptyTexture;
    }

    public void ResetGame()
    {
        foreach (var heart in _hearts)
        {
            Destroy(heart.Value);
        }

        Destroy(GameObject.FindGameObjectWithTag("MainCamera"));
        Destroy(GameObject.FindGameObjectWithTag("bgm"));

        Application.LoadLevel("Menu");
    }
}
