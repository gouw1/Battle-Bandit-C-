using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
	public float attackRange;
	public int attackDamage;
	public LayerMask Enemies;
	public Animator animate;
	private float attackRate = 2f;
	float nextAttackTime = 0f;
	
    void Update()
    {
		//Melakukan Serangan
		if(Time.time >= nextAttackTime)
		{
			if(Input.GetMouseButton(0))
			{
				animate.SetTrigger("Attack");
				Attack();
				nextAttackTime = Time.time + 1f / attackRate;
			}
		}
    }
	
	void Attack()
	{
		//Mendeteksi musuh
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, Enemies);
		
		//Damage
		foreach(Collider2D enemy in hitEnemies)
		{
			enemy.GetComponent<Enemies>().TakeDamage(attackDamage);
		}
	}
	
	//Area Serangan
	void OnDrawGizmosSelected()
	{
		if(attackPoint == null)
			return;
		
		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}
}
