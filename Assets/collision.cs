using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{
    public int score = 0; 
    public TMP_Text scoreText;
    public TMP_Text timerText; 
    public GameObject gameOverScreen; 
    private float timer = 15f; 
    private bool timerActive = false;
    [SerializeField] Color32 hasPackagecolor = new Color32 (1,1,1,1);
    [SerializeField] Color32 noPackagecolor = new Color32 (1,1,1,1);

    SpriteRenderer spr;

    void Start(){
        spr = GetComponent<SpriteRenderer>();
        UpdateScoreUI(); 
        gameOverScreen.SetActive(false);
    }
    bool hasPackage;
    [SerializeField] float destroyDelay = 0.5f;
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ouch!!");
        
    }
    void Update()
    {
        if (timerActive)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Clamp(timer, 0, timer).ToString("F0"); // Show timer

            if (timer <= 0)
            {
                GameOver();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "package" && hasPackage == false){
            Debug.Log("package has been taken");
            StartTimer();
            hasPackage = true;
            spr.color = hasPackagecolor;
            Destroy(other.gameObject,destroyDelay);
        }

        if(other.tag == "customer" && hasPackage == true){
            Debug.Log("package has been delivered");
            hasPackage = false;
            spr.color = noPackagecolor;
            DeliverPackage();
        }
    }

    void StartTimer()
    {
        timerActive = true; 
        timer = 15f; 
        timerText.gameObject.SetActive(true); 
    }
    void DeliverPackage()
    {
        score += 10; 
        UpdateScoreUI(); 
        timerActive = false;
        timerText.gameObject.SetActive(false);
    }

    void GameOver()
    {
        timerActive = false; 
        gameOverScreen.SetActive(true); 
        timerText.gameObject.SetActive(false); 
        GameObject restartButton = gameOverScreen.transform.Find("RestartButton").gameObject;
        restartButton.SetActive(true);
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString(); 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        gameOverScreen.transform.Find("RestartButton").gameObject.SetActive(false);
    }
}
