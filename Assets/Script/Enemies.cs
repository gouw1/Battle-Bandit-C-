using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
	public Animator animator;
	public Rigidbody2D rigidbody2D;
	public Transform player;
	public Canvas canvas;
	public HealtBar healthBar;
	public int maxHealth = 100;
	public bool isFlipped = false;
	
	int currentHealth;
	
	//Memanggil Variable
	void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}
	
	//Enemy Terkena Damage
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
	
	//Animasi Enemy Dead
	void Die()
	{
		Debug.Log("Enemy Died!!!");
		
		animator.SetBool("IsDead", true);
		
		rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
		canvas.enabled = false;
		GetComponent<Collider2D>().enabled = false;
		this.enabled = false; 
	}
	
	//Membentuk Animasi Melihat Player
	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z += -1f;
		
		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}
}
