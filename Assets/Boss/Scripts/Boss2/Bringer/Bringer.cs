using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bringer : MonoBehaviour
{
    
    private Animator animator;
    [SerializeField] public GameObject h_BulletEnemy;
    [SerializeField] public GameObject[] h_BulletEnemy2;
    public bool h_IsShoot = true;
    public float speed = 5;
    
    
    [SerializeField] bool h_IsCast=false;
    [SerializeField] float h_TimeAttack = 1;
    [SerializeField] float h_TimeCast = 2;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    void Start()
    {
        
        animator = GetComponent<Animator>();
        
        StartCoroutine(IsCast());
    }

    // Update is called once per frame
    void Update()
    {
        FindPlayer2();
        h_TimeAttack-=Time.deltaTime;
        h_TimeCast-=Time.deltaTime;
        
    }

    

    public void Attack3()
    {

            Vector3 pos = transform.position;
            pos += transform.right * attackOffset.x;
            pos += transform.up * attackOffset.y;
            Collider2D col = Physics2D.OverlapCircle(pos, attackRange, attackMask);
            if (col != null)
            {
                col.GetComponent<PlayerLife>().PlayerTakeDamage(col.GetComponent<PlayerLife>().GetTotalATK() + 50);
            }
       
        
    }

    public void Attack1()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Player01Animation");
        if (gameObject != null)
        {
            int randomNumber = Random.Range(0, 2);
            if (randomNumber == 0)
            {
                Vector3 vector3 = gameObject.transform.position;
                vector3.y = gameObject.transform.position.y + 2f;
                GameObject game = Instantiate(h_BulletEnemy, vector3, Quaternion.identity);
                AudioManager.instance.Play("EnemyAttack");
            }else if(randomNumber == 1)
            {
                Vector3 vector3 = gameObject.transform.position;
                GameObject game= Instantiate(h_BulletEnemy2[0], new Vector3(gameObject.transform.position.x+3,gameObject.transform.position.y),Quaternion.identity);
                GameObject game1 = Instantiate(h_BulletEnemy2[0], new Vector3(gameObject.transform.position.x - 3, gameObject.transform.position.y), Quaternion.identity);
                GameObject game3 = Instantiate(h_BulletEnemy2[1], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+5), Quaternion.identity);
            }
            
        }
        else
        {
            return;
        }
        

    }


    IEnumerator IsCast()
    {
        if (h_IsCast==true && h_TimeCast<=0)
        {
            
            yield return new WaitForSeconds(2);
            animator.ResetTrigger("IsCast");
        }
       
        
    }

    public void FindPlayer2()
    {
        GameObject player01Animation = GameObject.FindGameObjectWithTag("Player01Animation");

        if (player01Animation != null)
        {
            Transform playerTransform = player01Animation.transform;

            float direction = Vector3.Distance(playerTransform.position, transform.position);

            if (direction <= 3f && h_TimeAttack<=0)
            {
                animator.SetTrigger("IsAttack");
                h_TimeAttack = 1;

            }else if (direction >3  && direction <= 7)
            {
                h_IsCast = true;
            }else
            {
                h_IsCast = false;
            }

            if (h_IsCast == true && h_TimeCast <= 0)
            {
                animator.SetTrigger("IsCast");
                h_TimeCast = 2;
            }
            


            float enemyX = transform.position.x;
            float playerX = playerTransform.position.x;

            if (playerX < enemyX)
            {
                Vector3 newRotation = transform.eulerAngles;
                newRotation.y = 0; // Đặt góc y về 0
                transform.eulerAngles = newRotation;
            }
            else if (playerX > enemyX)
            {
                Vector3 newRotation = transform.eulerAngles;
                newRotation.y = 180; // Đặt góc y về 180 để quay ngược lại
                transform.eulerAngles = newRotation;
            }
            
        }
        else
        {
            return;
        }

    }
}
