using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerSpell : MonoBehaviour
{
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,0.7f);
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        Collider2D col= Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (col != null)
        {
            col.GetComponent<PlayerLife>().PlayerTakeDamage(col.GetComponent<PlayerLife>().GetTotalATK()+50);
        }
    }
}
