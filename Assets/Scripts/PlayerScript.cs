using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    public GameObject winPanel; // Ссылка на панель победы в UI

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (winPanel != null)
        {
            winPanel.SetActive(false); // Скрываем панель при старте
        }
    }

    void Update()
    {
        // Движение
        float moveX = Input.GetAxis("Horizontal") * speed;
        rb.linearVelocity = new Vector2(moveX, rb.linearVelocity.y);

        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверка земли
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // Смерть при касании опасного объекта
        if (collision.gameObject.CompareTag("Opasnost"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Upal"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("KillEnemy"))
        {
            GameObject objectToDestroy = GameObject.FindWithTag("Enemy");
            Destroy(objectToDestroy);
        }



        if (collision.gameObject.CompareTag("WIN"))
        {
            Win();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // В самом конце класса PlayerScript добавьте:

    public void RestartGame()
    {
        Time.timeScale = 1f; // Сбрасываем паузу если была
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Win()
    {
        Debug.Log("Победа!");

        // Останавливаем игровое время (пауза)
        Time.timeScale = 0f;

        // Показываем панель победы
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        
    }

}