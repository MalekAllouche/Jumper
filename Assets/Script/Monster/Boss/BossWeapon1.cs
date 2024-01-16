using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon1 : MonoBehaviour
{
    private int attackDamage = 2;
	private int enragedAttackDamage = 10;
    // private float attackCooldown = 2f;
    private float lastAttackTime;
	public Animator animator;
	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;
    public GameObject rangedAttackPrefab;

    public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;


		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
		}
	}
    public void EnragedAttack()
	{
		animator.SetTrigger("EnAttack");
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerHealth>().TakeDamage(enragedAttackDamage);
		}

    }
    private void resetTriggers()
    {
		animator.ResetTrigger("EnAttack");
    }
    void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
