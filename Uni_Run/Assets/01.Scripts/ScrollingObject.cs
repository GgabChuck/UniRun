using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    // ���� ������Ʈ�� ��� �������� �����̴� ��ũ��Ʈ
    public float speed = 10f; // �̵� �ӵ�
    void Update()
    {
        // ���ӿ����� �ƴ϶��
        if (!GameManager.instance.isGameover)
        { 
        // �ʴ� speed�� �ӵ��� �������� �����̵�
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
