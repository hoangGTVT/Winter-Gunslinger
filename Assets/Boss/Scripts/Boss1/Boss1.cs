using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    private Animator animator;
    [SerializeField] public GameObject[] h_BulletEnemy;
    [SerializeField] public Transform h_Point;
    [SerializeField] public float h_TimeAttack = 2;
    [SerializeField] public float h_TimeAttack1 = 3;

    public int numBullets = 5; // Số lượng viên đạn bạn muốn tạo ra.
    public float spacing = 2f; // Khoảng cách giữa các viên đạn trên trục x.
    public float minY = 5f; // Vị trí trục y cố định.
    public float radius = 5f;

    public Transform[] targetPoints;
    public float moveSpeed = 1.0f;
    private int currentTargetIndex = 0;
    private Transform currentTarget;
    void Start()
    {
        animator = GetComponent<Animator>();
        if (targetPoints.Length > 0)
        {
            currentTarget = targetPoints[currentTargetIndex];
        }
        StartCoroutine(BossMove());
    }

    // Update is called once per frame
    void Update()
    {
        FindPlayer2();
        if (h_TimeAttack > 0)
        {
            h_TimeAttack -= Time.deltaTime;
        }
        if (h_TimeAttack1 > 0)
        {
            h_TimeAttack1-= Time.deltaTime;
        }
       
        if (Input.GetKeyDown(KeyCode.W))
        {
            CreateBullet();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Move();
        }
    }

    IEnumerator BossMove()
    {
        yield return new WaitForSeconds(5);
        while(true)
        {
            Move();
            Boss boss= GetComponent<Boss>();
            if (boss != null)
            {
                boss.HealHP();
                
            }
            yield return new WaitForSeconds(5);
        }
        
    }

    public void Move()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player01Animation");
        if (player != null)
        {
            if (currentTarget != null)
            {
                if (currentTargetIndex > 3)
                {
                    currentTargetIndex= -1;
                }
                transform.position = currentTarget.position;

                if (Vector3.Distance(transform.position, currentTarget.position) < 0.001f)
                {
                    currentTargetIndex++;
                    if (currentTargetIndex < targetPoints.Length)
                    {
                        currentTarget = targetPoints[currentTargetIndex];
                    }else

                    if(currentTargetIndex > targetPoints.Length)
                    {
                        currentTarget.position = player.transform.position;
                        Vector3 position = currentTarget.position;
                        position.x += 4;
                        currentTarget.position = position;
                    }
                     
                }
            }
        }
        else
        {
            return;
        }
        
    }


    public void Attack1()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Player01Animation");
        if (gameObject != null)
        {
            
            GameObject game = Instantiate(h_BulletEnemy[0], h_Point.position, Quaternion.identity);
            AudioManager.instance.Play("EnemyAttack");
        }
        else
        {
            return;
        }


    }

    public void FindPlayer2()
    {
        GameObject player01Animation = GameObject.FindGameObjectWithTag("Player01Animation");

        if (player01Animation != null)
        {
            Transform playerTransform = player01Animation.transform;

            float direction = Vector3.Distance(playerTransform.position, transform.position);

            if (direction <= 5f && h_TimeAttack <= 0)
            {
                animator.SetTrigger("IsAttack");
                h_TimeAttack = 1;

            }
            if (direction > 5 && h_TimeAttack1<=0)
            {
                animator.SetTrigger("IsSkill");
                h_TimeAttack1 = 3;
               
            }



            float enemyX = transform.position.x;
            float playerX = playerTransform.position.x;

            if (playerX > enemyX)
            {
                Vector3 newRotation = transform.eulerAngles;
                newRotation.y = 0; // Đặt góc y về 0
                transform.eulerAngles = newRotation;
            }
            else if (playerX < enemyX)
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


    public void CreateBullet()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player01Animation");
       if (player != null)
        {
            Vector3 playerPosition = player.transform.position; // Lấy vị trí của người chơi (đối tượng chứa kịch bản này).

            for (int i = 0; i < numBullets; i++)
            {
                float randomX = playerPosition.x + Random.Range(-radius, radius); // Tạo một giá trị x ngẫu nhiên trong khoảng bán kính quanh vị trí của người chơi.
                Vector3 spawnPosition = new Vector3(randomX, minY, 0); // Tạo vị trí mới dựa trên giá trị x ngẫu nhiên và vị trí y cố định.
                AudioManager.instance.Play("EnemyAttack");
                Instantiate(h_BulletEnemy[1], spawnPosition, Quaternion.identity); // Tạo một viên đạn tại vị trí đã tính toán.
            }
        }else { return; }
        
        
    }
   
 }
