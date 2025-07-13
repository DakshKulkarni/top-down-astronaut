using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject secondCharPrefab;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private static PlayerController instance;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput = moveInput.normalized;
        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            spriteRenderer.flipX = (moveInput.x < 0);
        }
        animator.SetBool("isMoving", moveInput != Vector2.zero);
        if (Input.GetKeyDown(KeyCode.J))
        {
            string current = SceneManager.GetActiveScene().name;
            string next = (current == "Demo Tilemap") ? "Demo Colors" : "Demo Tilemap";
            SceneManager.LoadScene(next);
        }
        //lazy instantiation for a second character, it gets spawned only when pressed H with the 
        //instance that was set in secondcharmanager script 
        if (Input.GetKeyDown(KeyCode.H))
        {
            Vector3 spawnPos = transform.position + new Vector3(2f, 0, 0);
            SecondCharManager.SpawnSecondChar(secondCharPrefab, spawnPos);
        }
    }
    void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }
}
