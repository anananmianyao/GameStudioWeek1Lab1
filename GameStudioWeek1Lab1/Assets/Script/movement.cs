using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class movement : MonoBehaviour
{
    public float speed = 5f;
    public Text txt;
    public Text txt1;
    public int Holding = 0;
    public int Score = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tree")
        {
            SceneManager.LoadScene(1);
        }
        if (other.gameObject.tag == "Solider" && Holding <3)
        {
            
                Holding++;
                Destroy(other.gameObject);
                txt.text = "Holding: " + Holding.ToString();
            
        }
        else if (other.gameObject.tag == "Solider" && Holding ==3)
        {
            Debug.Log("FULL");
        }
        if (other.gameObject.tag == "Hospital")
        {
            Score = Score + Holding;
            txt1.text = "Score: " + Score.ToString();
            Holding = 0;
            txt.text = "Holding: " + Holding.ToString();
        }
        if (Score == 7)
        {
            SceneManager.LoadScene(2);
        }
    }
        // Update is called once per frame
        void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 position = transform.position;
        position.x += moveX * speed * Time.deltaTime;
        position.y += moveY * speed * Time.deltaTime;
        transform.position = position;

        RestartGame();
    }

    void RestartGame()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(0);
        }
    }
}


