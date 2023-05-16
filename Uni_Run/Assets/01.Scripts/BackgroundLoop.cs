using UnityEngine;

// ���� ������ �̵��� ����� ������ ������ ���ġ�ϴ� ��ũ��Ʈ
public class BackgroundLoop : MonoBehaviour
{
    private float width; // ����� ���� ����    
    void Awake()
    {
        // BoxCollider2D ������Ʈ�� Size �ʵ��� x ���� ���� ���̷� ���
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }
    void Update()
    {
        // ���� ��ġ�� �������� �������� width �̻� �ൿ���� �� ��ġ�� ���ġ
        if(transform.position.x <= -width)
        {
            Reposition();
        }
    }
    // ��ġ�� ���ġ�ϴ� �޼���
    void Reposition()
    {
        // ���� ��ġ���� �����U���� ���� ���� * 2��ŭ �̵�
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
