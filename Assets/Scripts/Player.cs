using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float jumpForce;
    Rigidbody2D m_rb;
    bool m_isGround ;
    GameController m_gc;
    public AudioSource aus;
    public AudioClip loseSound;
    public AudioClip jumpSound;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

        bool isJumKeyPressed = Input.GetKeyDown(KeyCode.Space);

        if(isJumKeyPressed && m_isGround){

            // vector2.up = (0, 1) => (0, 1) * 5 = (0, 5)
            m_rb.AddForce(Vector2.up * jumpForce);
            m_isGround = false;

            if(aus && jumpSound && !m_gc.IsGameOver()){
                aus.PlayOneShot(jumpSound);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("Ground")){
            m_isGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Wall")){
            if(aus && loseSound && !m_gc.IsGameOver()){
                aus.PlayOneShot(loseSound);
            }
            m_gc.SetGameOverState(true);
        }
    }

}
