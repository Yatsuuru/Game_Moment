using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    private Animator anim;

    public GameObject goWin;
    public GameObject goDIE;
    public Camera mainCamera; // ������ �� ������� ������
    private bool isDead = false; // ����, �����������, ��� ����� ����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mainCamera = Camera.main; // �������� ������ �� ������� ������
    }

    void FixedUpdate()
    {
        if (!isDead) // ���������, �� ���� �� �����
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

            if (moveHorizontal > 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                anim.SetBool("IsRunning", true);
            }
            else if (moveHorizontal < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                anim.SetBool("IsRunning", true);
            }
            else
            {
                anim.SetBool("IsRunning", false);
            }
        }
    }

    private void LateUpdate()
    {
        if (!isDead) // ���������, �� ���� �� �����
        {
            // ���������� ������ �� �������
            Vector3 newPosition = transform.position;
            newPosition.z = mainCamera.transform.position.z;
            mainCamera.transform.position = newPosition;
        }
    }

    private void Update()
    {
        if (!isDead && Input.GetKeyDown(KeyCode.Space)) // ���������, �� ���� �� �����
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("Jump", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("Jump", false);
        }
        if (collision.gameObject.CompareTag("DIE"))
        {
            goDIE.SetActive(true);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("WIN"))
        {
            goWin.SetActive(true);

        }
    }
}
