using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BubblePopUp : MonoBehaviour
{
    [SerializeField] private float growTime;

    [SerializeField] private Sprite pow;
    [SerializeField] private Sprite bang;
    [SerializeField] private Sprite boing;
    [SerializeField] private Sprite wham;

    [SerializeField] private Image image;
    void Start()  
    {
        PopAway();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PopUp();
        }
    }

    public void PopUp()
    {
        int selection = Random.Range(0, 3);
        switch (selection)
        {
            case 0: image.sprite = pow;
                break;
            case 1: image.sprite = bang;
                break;
            case 2: image.sprite = boing;
                break;
            case 3: image.sprite = wham;
                break;
        }
        transform.DOScale(1, growTime).SetEase(Ease.OutElastic).OnComplete(PopAway);
    }

    public void PopAway()
    {
        transform.localScale = Vector3.zero;
    }
}
