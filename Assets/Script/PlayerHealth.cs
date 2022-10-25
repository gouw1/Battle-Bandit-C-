using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public Animator animator;
	public int maxHealth;
	public int currentHealth;
	public HealtBar healthBar;
	public GameObject panel;
	
    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }
	
	//Menerima Damage
	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
		
		animator.SetTrigger("Hurt");
		
		if(currentHealth <= 0)
		{
			Die();
		}
	}
	
	//Player Death
	void Die()
	{
		
		animator.SetBool("Death", true);

		GetComponent<Collider2D>().enabled = false;
		this.enabled = false;
		panel.SetActive(true);

	}
}
