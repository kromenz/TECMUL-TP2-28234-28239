using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    bool alive = true;
    bool isJumping = false;

    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;
    public float speedIncreasePerPoint = 0.1f;

    private void FixedUpdate ()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }


    private void Update () {

        horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space)){
           Jump();
        }

        if (transform.position.y < -5) {
            Die();
        }
    }

    public void Die ()
    {
        alive = false;
        // Restart the game
        Invoke("Restart", 2);
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump(){
        // Verificar se já estamos pulando
        if (isJumping) return;
        
        // Verificar se estamos no chão
        if (Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            // Se estamos no chão, pular
            rb.AddForce(Vector3.up * jumpForce);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Resetar o estado de pulo quando colidir com o chão
        isJumping = false;
    }
}
