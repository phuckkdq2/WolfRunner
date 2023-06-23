using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject wall;

    public float spawnTime ;
    float m_spawnTime;
    bool m_isGameOver;
    int m_score;
    UIManager m_ui;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0 ;
        spawnTime = 2;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScore("score : "+ m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isGameOver){
            m_spawnTime = 0 ;
            m_ui.ShowGameOverPanel(true);
            return;
        }


        m_spawnTime -= Time.deltaTime;

        if(m_spawnTime <= 0){
            SpawnWall();
            m_spawnTime = spawnTime;
        }
    }

    public void SpawnWall(){
        float randYpos = Random.Range(-3.5f, -1.97f);
        Vector2 SpawnRandXpos = new Vector2(11, randYpos);

        if(wall){
            Instantiate(wall, SpawnRandXpos, Quaternion.identity);
        }
    }

    public void SetScore(int value){
        m_score = value;
    }

    public int GetScore(){
        return m_score;
    }

    public void ScoreIncrement(){
        if(m_isGameOver){
            return;
        }
        m_score ++;
        m_ui.SetScore("Score : " + m_score);
    }

    public bool IsGameOver(){
        return m_isGameOver;
    }

    public void SetGameOverState(bool state){
        m_isGameOver = state;
    }
    
    public void Replay(){
        SceneManager.LoadScene("GamePlay");
    }
}
