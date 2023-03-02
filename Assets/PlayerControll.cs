using TMPro;
using UnityEngine;
public class PlayerControll : MonoBehaviour
{
    public float moveSpeed = 5f; // Player movement speed
    public float jumpForce = 10f; // Player jump force
    public LayerMask groundLayer; // Layer for detecting ground
    public Transform groundCheck; // Transform for checking if player is on the ground
    public GameObject inGameUi;
    public GameObject endGameUi;
    public TextMeshProUGUI inGameScoreboard;
    public TextMeshProUGUI endGameScoreboard;
    public TextMeshProUGUI energyDisplay;
    public int energy = 100;
    private int drainDelta = 1;
    private Rigidbody2D rb; // Reference to player's Rigidbody2D component
    //private Animator anim; // Reference to player's Animator component
    private bool isGrounded; // Flag for checking if player is on the ground
    private int score = 0;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    private void Start() {
		InvokeRepeating("drainEnergy", 0, 1);
		InvokeRepeating("increaseDrainEnergy", 0, 5);
    }

    private void Update()
    {

        // Check if player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        Debug.Log(isGrounded);
        // Play run animation if player is moving
        //anim.SetBool("IsRunning", Mathf.Abs(horizontalInput) > 0);
        // Check if player pressed jump button and is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Add jump force to player
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        // Get horizontal input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        // Move player horizontally
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if player collides with sunray object
        if (collision.gameObject.CompareTag("Sunray"))
        {
            // Add sunray to player's inventory (or perform other action as needed)
            Debug.Log("Collected sunray object!");
            // Destroy sunray object
            Destroy(collision.gameObject);
            score += 10;
            inGameScoreboard.text = "Score: " + score + "kWh";
            this.chargeEnergy();
        }
    }

    private void drainEnergy() {
        energy -= drainDelta;
        if (energy < 0 && enabled) {
            inGameUi.SetActive(false);
            endGameScoreboard.text = "Score: " + score + "kWH";
            endGameUi.SetActive(true);
            enabled = false;
        }
        updateEnergyDisplay();
    }

    private void increaseDrainEnergy() {
        this.drainDelta += 1;
    }

    private void chargeEnergy() {
        this.energy = Mathf.Min(100, this.energy + 1);
        updateEnergyDisplay();
    }

    private void updateEnergyDisplay() {
        this.energyDisplay.text = "Energy: " + this.energy + "%";
    }
}