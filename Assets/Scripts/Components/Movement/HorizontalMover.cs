using UnityEngine;

/// <summary>
/// Moves transform horizontally based on keyboard input (A/D or Arrow keys).
/// </summary>
public class HorizontalMover : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;
    
    [Header("Optional")]
    [SerializeField] private bool flipSprite = true;
    
    private SpriteRenderer spriteRenderer;
    private bool isLanded = false; // коли впав Ч true

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        // €кщо блок уже впав Ч не реагуЇмо на натисканн€
        if (isLanded)
            return;

        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);
        
        if (flipSprite && spriteRenderer != null && horizontal != 0)
        {
            spriteRenderer.flipX = horizontal < 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // можна вказати тег, щоб реагувати лише на землю чи ≥нш≥ блоки
        if (collision.gameObject.CompareTag("Ground"))
        {
            isLanded = true;
        }
    }
}
