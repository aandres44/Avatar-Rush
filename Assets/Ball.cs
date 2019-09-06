using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    public float speed;
    public int score;
    public Text countText,
                winText;

    private Rigidbody rb;

    public Transform original;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winText.text = "";
        score = 3;
    }

    // Update is called once per frame
    void Update()
    {
        float u = Input.GetAxis("Horizontal");
        float s = Input.GetAxis("Vertical");

        transform.Translate
            (
            s * Time.deltaTime * speed,
            0,
            - u * Time.deltaTime * speed,
            Space.World
            );

        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y == 0.5)
        {
            rb.AddForce(transform.up * 5, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            //print("chocamos");
            score--;
        }

        if (collision.gameObject.layer == 9)
        {
            
        }

        SetCountText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            transform.position = original.position;
            score++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + score.ToString();
        if (score == 10)
        {
            winText.text = "Ganaste";
        }
    }
}
