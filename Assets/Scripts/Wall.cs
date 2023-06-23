using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public float moveSpeed;

    GameController m_gc;
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
        // vector3.left = (-1,0,0) 
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("SeenLimit")){

            m_gc.ScoreIncrement();

            Debug.Log("+1");

            Destroy(gameObject);
        }
    }
}
