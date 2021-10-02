using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformOpacity : MonoBehaviour
{
    Transform _player;
    Renderer _renderer;

    public bool wasHitBefore = false;

    public void hit()
    {
        wasHitBefore = true;
        Color color = _renderer.material.GetColor("_AlbedoColor");
        color.r = 1;
        color.g = 0;
        color.b = 0;
        _renderer.material.SetColor("_AlbedoColor", color);
    }
    
    void Start()
    {
        _player = FindObjectOfType<PlayerController>().GetComponent<Transform>();
        _renderer = GetComponent<Renderer>();
    }

    void SetTransparency(float val)
    {
        Color color = _renderer.material.GetColor("_AlbedoColor");
        color.a = val;
        _renderer.material.SetColor("_AlbedoColor", color);
    }
    void Update()
    {
        float distance = Vector3.Distance(_player.position, transform.position);
        if (distance < 25)
        {
            SetTransparency(1f);
        }
        else
        {
            SetTransparency(0.1f);
        }
    }
}
