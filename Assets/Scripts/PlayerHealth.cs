using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public float CurrentHealth;
    public float MaxHealth;
    public Slider healthbar;

	// Use this for initialization
	void Start () {
        MaxHealth = 20f;
        CurrentHealth = MaxHealth;
	}
	
	// Update is called once per frame
	void Update (Collider2D other) {
        if (other.CompareTag("Enemy")) {
            DealDamage(5);
        }
    }

    void DealDamage(float Damage) {
        CurrentHealth -= Damage;
        if (CurrentHealth <= 0) Die();
    }

    void Die() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
