using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq.Expressions;
//using System;

public class SpawnManager : MonoBehaviour
{
    public Button RestartButton;
    public Button StartButton;
    public TextMeshProUGUI Nutrexplosion;
    public TextMeshProUGUI variablesPro;
    public TextMeshProUGUI GameoverWinText;
    public TextMeshProUGUI GameoverLoseText;
    public GameObject player;
    public GameObject[] foodPrefabs;
    private float t = 0;
    private float finalTime = 0;
    private float spawnRangeX = 9;
    private float startDelay = 2;
    private float spawnInterval = 0.8f;
    public AudioClip VictorySound;
    public AudioClip LoseSound;
    public AudioClip[] clips;
    public AudioSource audioSource;
    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isGameActive) {
            if (((Apple.vitamin >= 10) && (Bread.carbonhydrate >= 10) && (Chickenleg.protein >= 10))||(FatFood.fat>5)) { GameOver(); }
            else { displayVariables(); } }
    }
    void SpawnRandomFood()
    {
        int foodIndex = Random.Range(0, 4);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 6, 1);
        if (isGameActive)
        {
            Instantiate(foodPrefabs[foodIndex], spawnPos, foodPrefabs[foodIndex].transform.rotation);
        }
    }
    private void displayVariables()
    {
         t = t + Time.deltaTime; variablesPro.text = "Carbonhydrate: " + Bread.carbonhydrate.ToString() + "/10" + "\n" + "Protein: " + Chickenleg.protein.ToString() + "/10" + "\n" + "Vitamin: " + Apple.vitamin.ToString() + "/10" + "\n" +"Trans Fat: "+FatFood.fat.ToString()+"/5"+"\n"+ t.ToString(); 
    }
    public void GameOver() {
        audioSource.Stop();
        isGameActive = false;
        RestartButton.gameObject.SetActive(true);
        variablesPro.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        
        if (FatFood.fat > 5) { GameoverLoseText.gameObject.SetActive(true);
            audioSource.PlayOneShot(LoseSound, 12.9f);
        }
        else
        {
            finalTime = t; GameoverWinText.text = "Yummy! What a balanced diet!" + "\n" + "Your Time: " + finalTime.ToString();
            audioSource.PlayOneShot(VictorySound, 12.9f);
            GameoverWinText.gameObject.SetActive(true);
        }
        Apple.vitamin = 0;
        Bread.carbonhydrate = 0;
        Chickenleg.protein = 0;
        FatFood.fat = 0;
        t = 0;
        finalTime = 0;
        PlayerControl.moveSpeed = 10.0f;
}

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame() {
        RestartButton.gameObject.SetActive(false);
        GameoverWinText.gameObject.SetActive(false);
        GameoverLoseText.gameObject.SetActive(false);
        isGameActive = true;
        variablesPro.gameObject.SetActive(true);
        Nutrexplosion.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
        StartButton.gameObject.SetActive(false);
        audioSource.clip = GetRandomClip();
        audioSource.Play();
        Apple.vitamin = 0;
        Bread.carbonhydrate = 0;
        Chickenleg.protein = 0;
        FatFood.fat = 0;
        InvokeRepeating("SpawnRandomFood", startDelay, spawnInterval);
    }
    public AudioClip GetRandomClip()
    {
        return clips[Random.Range(0, clips.Length)];

    }
}

