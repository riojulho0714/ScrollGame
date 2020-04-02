using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float walkForce1 = 30.0f;
    private float walkForce2 = 50.0f;
    private float maxWalkSpeed1 = 5.0f;
    private float maxWalkSpeed2 = 8.0f;
    private float jumpForce = 20f;
    private Animator animator;
    private Rigidbody2D rigid2D;
    private bool isGrounded;
    GameObject obj;
    public Text GoalText;
    public GameObject replaybutton2;
    GameObject timerText;
    GameObject gameOverText;
    public Text GameOverText;
    private bool gameOver = false;
    public GameObject replaybutton1;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.obj = GameObject.Find("Cat");
        this.replaybutton2 = GameObject.Find("ReplayButton2");
        replaybutton2.SetActive(false);
        this.timerText = GameObject.Find("Time");
        this.gameOverText = GameObject.Find("GameOverText");
        this.animator = GetComponent<Animator>();
        this.replaybutton1 = GameObject.Find("ReplayButton1");
        replaybutton1.SetActive(false);
        isGrounded = true;
        this.animator.SetBool("MoveBool", false); //最初は静止した状態
    }

    void Update()
    {
        //プレイヤーが落ちたら非表示
        if (transform.position.y < -10.0f)
        {
            obj.SetActive(false);
        }

        Walk(); //歩いている時の処理
        Dash(); //走っている時の処理
        Jump(); //ジャンプに関する処理

        if (!isGrounded)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.RightArrow) && isGrounded)
            {
                animator.Play("Dash");
                this.animator.SetBool("MoveBool", true);
            }

            else if (Input.GetKey(KeyCode.LeftArrow) )
            {
                animator.Play("Dash");
                this.animator.SetBool("MoveBool", true);
            }

            else
            {
                this.animator.SetBool("MoveBool", false);
            }
        }

        else
        {
            if (Input.GetKey(KeyCode.RightArrow) && isGrounded)
            {
                animator.Play("Walk");
                this.animator.SetBool("MoveBool", true);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && isGrounded)
            {
                animator.Play("Walk");
                this.animator.SetBool("MoveBool", true);
            }

            else
            {
                this.animator.SetBool("MoveBool", false);
            }


        }
    }


    void Walk()
        {
            //左右移動
            int key = 0;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                key = 2;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                key = -2;
            }
            
            //プレイヤーの速度
            float speedx1 = Mathf.Abs(this.rigid2D.velocity.x);

            //スピード制限
            if (speedx1 < this.maxWalkSpeed1)
            {
                this.rigid2D.AddForce(transform.right * key * this.walkForce1);
            }

            if (key != 0)
            {
                //プレイヤーのスケールを2で調整
                transform.localScale = new Vector3(key, 2, 2);
            }
        }

        void Dash()
        {
            //左右移動
            int key = 0;

            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.Space)
                && isGrounded == true)
            {
                key = 2;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.Space)
                && isGrounded == true)
            {
                key = -2;
            }

            //プレイヤーの速度
            float speedx2 = Mathf.Abs(this.rigid2D.velocity.x);

            //スピード制限
            if (speedx2 < this.maxWalkSpeed2)
            {
                this.rigid2D.AddForce(transform.right * key * this.walkForce2);
            }

            if (key != 0)
            {
                //プレイヤーのスケールを2で調整
                transform.localScale = new Vector3(key, 2, 2);
            }

        }

        void Jump()
        {
            if (isGrounded)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    animator.Play("Jump");
                    this.animator.SetBool("MoveBool", true);
                    rigid2D.velocity = Vector3.up * jumpForce;
                    isGrounded = false;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground" ||
            collision.gameObject.tag == "Dokan" ||
            collision.gameObject.tag == "Block")
            {
                isGrounded = true;
            }

            //敵と衝突した時の処理
            if (collision.gameObject.tag == "Enemy")
            {
                foreach(ContactPoint2D p in collision.contacts)
                {
                    if (p.point.y < transform.position.y - 0.6f)
                    {
                        Destroy(collision.gameObject);
                    }
                else
                {
                    gameOver = true;

                    if (gameOver)
                    {
                        GameOverText.enabled = true;
                        replaybutton1.SetActive(true);
                        timerText.SetActive(false);
                        obj.SetActive(false);
                    }

                }
            }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //ゴールの処理
            if (collision.gameObject.tag == "Finish")
            {
                GoalText.enabled = true;
                replaybutton2.SetActive(true);
                timerText.SetActive(false);
                gameOverText.SetActive(false);
            }
        }
    }


