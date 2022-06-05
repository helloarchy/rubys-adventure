using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int healthAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var rubyController = other.GetComponent<RubyController>();

        if (rubyController != null)
        {
            // Only apply health if not full
            if(rubyController.CurrentHealth < rubyController.maxHealth)
            {
                rubyController.ChangeHealth(healthAmount);
                Destroy(gameObject);
            }
        }
    }
}
