using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider Slider;
    public Vector3 Offset;

    private void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }

    public void SetHealth(float health)
    {
        Slider.maxValue = 50;
        Slider.value = health;

        if (health <= 0)
        {
            Slider.gameObject.SetActive(false);
        }
    }
}