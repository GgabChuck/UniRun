using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; // ��� �� ����� ����� Ŭ��
    public float jumpForce = 700f; // ���� ��

    private int jumpCount = 0; // ���� ���� Ƚ��
    private bool isGrounded = false; // �ٴڿ� ��Ҵ��� ��Ÿ��
    private bool isDead = false; // ��� ����

    private Rigidbody2D playerRigidbody; // ����� ������ٵ� ������Ʈ
    private Animator animator; // ����� �ִϸ����� ������Ʈ
    private AudioSource playerAudio; // ����� ����� �ҽ� ������Ʈ
    void Start()
    {
        // ���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ������ �Ҵ�
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(isDead)
        {
            // ��� �� ó���� �� �̻� �������� �ʰ� ����
            return;
        }
        // ���콺 ���� ��ư�� �������� && �ִ� ���� Ƚ��(2)�� �������� �ʾҴٸ�
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            // ���� Ƚ�� ����
            jumpCount++;
            // ���� ������ �ӵ��� ���������� ����(0, 0)�� ����
            playerRigidbody.velocity = Vector2.zero;
            // ������ٵ� �������� �� �ֱ�
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            // ����� �ҽ� ���
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            // ���콺 ���� ��ư���� ���� ���� ���� && �ӵ��� y ���� ������(���� ��� ��) ���� �ӵ��� �������� ����
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
        // �ִϸ������� Grounded �Ķ���͸� isGround ������ ����
        animator.SetBool("Grounded", isGrounded);
    }
    void Die()
    {
        // �ִϸ������� Die Ʈ���� �Ķ���͸� ��
        animator.SetTrigger("Die");
        // ����� �ҽ��� �Ҵ�� ����� Ŭ���� deathClip���� ����
        playerAudio.clip = deathClip;
        // ��� ȿ���� ���
        playerAudio.Play();

        // �ӵ��� ����(0, 0)�� ����
        playerRigidbody.velocity = Vector2.zero;
        // ��� ���¸� true�� ����
        isDead = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && !isDead)
        {
            // �浹�� ������ �±װ� Dead�̸� ���� ������� �ʾҴٸ� Die() ����
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �ٴڿ� ������� �����ϴ� ó��
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // �ٴڿ��� ������� �����ϴ� ó��
    }
}