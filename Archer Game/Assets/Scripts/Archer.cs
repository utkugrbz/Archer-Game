using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Archer : MonoBehaviour
{
    public Transform direction1;
    public Global.PlayerType playerType;
    public GameObject arrowPrefab;
    public float moveSpeed;
    public Animator animator;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float hp = 10;
    public float damage = 1;
    float shootTime = 0;
   

    private void Start()
    {
        if (playerType == Global.PlayerType.Player1)
            direction1.DORotate(Vector3.forward * 45, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        else
            direction1.DOLocalRotate(Vector3.back * 135, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
    void Update()
    {
        if(LevelManager.Instance.isGameStart)
        {
            switch (playerType)
            {
                case Global.PlayerType.Player1:
                    if (Input.GetKey(KeyCode.S))                             
                    {
                        transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);  
                        animator.SetInteger("SpeedY", -1);
                    }
                    if (Input.GetKey(KeyCode.W))                   
                    {
                        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
                        animator.SetInteger("SpeedY", 1);
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
                        animator.SetInteger("SpeedX", 1);
                    }

                    if (Input.GetKey(KeyCode.A))
                    {
                        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
                        animator.SetInteger("SpeedX", -1);
                    }
                    if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
                        animator.SetInteger("SpeedX", 0);
                    if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
                        animator.SetInteger("SpeedY", 0);
                    break;
                case Global.PlayerType.Player2:
                    if (Input.GetKey(KeyCode.DownArrow))                          
                    {
                        transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);     
                        animator.SetInteger("SpeedY", -1);
                    }
                    if (Input.GetKey(KeyCode.UpArrow))                      
                    {
                        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
                        animator.SetInteger("SpeedY", 1);
                    }
                    if (Input.GetKey(KeyCode.RightArrow))
                    {
                        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
                        animator.SetInteger("SpeedX", 1);
                    }

                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
                        animator.SetInteger("SpeedX", -1);
                    }
                    if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
                        animator.SetInteger("SpeedX", 0);
                    if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
                        animator.SetInteger("SpeedY", 0);
                    break;
            }

            if ((animator.GetInteger("SpeedX") == 0 && animator.GetInteger("SpeedY") == 0) && Time.time > shootTime && LevelManager.Instance.isGameStart)
            {
                shootTime = Time.time + 1;
                Rigidbody2D rb = Instantiate(arrowPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
                if (direction1)
                {
                    rb.velocity = direction1.up.normalized * 4;
                    float angle = Mathf.Atan2(rb.velocity.x, rb.velocity.y) * Mathf.Rad2Deg;
                    rb.transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
                }

            }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
        }
       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Destroy(collision.gameObject);
            hp -= damage;
            UIManager.Instance.OnPlayerDamage(this);
        }
        if (hp <= 0)
        {
            direction1.DOKill();
            Destroy(gameObject);
        }

    }

}
