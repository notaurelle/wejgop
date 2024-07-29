using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Camera healthBarCamera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = camera.transform.rotation; 
        //transform.position = target.position + offset;

        // Ensure the health bar follows the target's position plus the offset
        Vector3 targetPosition = target.position + offset;
        transform.position = targetPosition;

        // Make the health bar face the camera if you want it to always be visible
        if (healthBarCamera != null)
        {
            transform.LookAt(transform.position + healthBarCamera.transform.rotation * Vector3.forward,
                             healthBarCamera.transform.rotation * Vector3.up);
        }
    }
}
