using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; // �������� ��������
    [SerializeField] private float moveDistance = 1f; // ��������� �������� � ���� �������

    private Vector3 startPosition;
    private bool movingRight = true;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // ������������ ����� �������
        float newX = startPosition.x + (movingRight ? 1 : -1) * Mathf.PingPong(Time.time * moveSpeed, moveDistance);

        // ��������� ����� �������
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        // �����������: �������� �������
        if ((movingRight && newX < transform.position.x) || (!movingRight && newX > transform.position.x))
        {
            movingRight = !movingRight;
            Flip();
        }
    }

    private void Flip()
    {
        // �������� ������� �� �����������
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}