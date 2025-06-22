using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; // Скорость движения
    [SerializeField] private float moveDistance = 1f; // Дистанция движения в одну сторону

    private Vector3 startPosition;
    private bool movingRight = true;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Рассчитываем новую позицию
        float newX = startPosition.x + (movingRight ? 1 : -1) * Mathf.PingPong(Time.time * moveSpeed, moveDistance);

        // Применяем новую позицию
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        // Опционально: разворот спрайта
        if ((movingRight && newX < transform.position.x) || (!movingRight && newX > transform.position.x))
        {
            movingRight = !movingRight;
            Flip();
        }
    }

    private void Flip()
    {
        // Разворот спрайта по горизонтали
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}