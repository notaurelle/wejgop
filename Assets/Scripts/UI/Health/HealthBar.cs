using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // Set the maximum health and initialize the health bar
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    // Update the health bar's value and color
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        Debug.Log("Health updated: " + health);
    }

    // Get the current health value from the slider
    public int GetHealth()
    {
        return (int)slider.value;
    }

    // Get the maximum health value from the slider
    public int GetMaxHealth()
    {
        return (int)slider.maxValue;
    }
}