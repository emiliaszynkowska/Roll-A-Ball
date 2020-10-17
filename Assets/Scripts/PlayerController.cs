using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody body;
    private float movementX;
    private float movementY;
    public TextMeshProUGUI scoreText;
    public GameObject winTextObject;
    private int score;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
        winTextObject.SetActive(false);
    }

    void Update()
    {
        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX,0,movementY);
        body.AddForce(movement * speed);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
        }
    }
    
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();

        if (score >= 12) 
        {
            winTextObject.SetActive(true);
        }
    }
}