using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public int level = 1;
    public int experience = 0;
    public int currentLevel;

   
    public Text playerLevelText;
    public Text playerexperienceText;
    public Text currentLevelText;

    public void Save()
    {
        SaveLoad.Save(this);
    }

    public void Load()
    {
        PlayerData data = SaveLoad.Load();

        
        level = data.level;
        experience = data.experience;
        currentLevel = data.currentLevel;


        if (currentLevel == 1)
        {
            SceneManager.LoadScene(1);
        }

        if (currentLevel == 2)
        {
            SceneManager.LoadScene(2);
        }

        if (currentLevel == 0)
        {
            SceneManager.LoadScene(0);
        }
    }

  

    void Awake()
   {
        GameObject[] gameController = GameObject.FindGameObjectsWithTag("GameController");
        if(gameController.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        GameObject[] canvas = GameObject.FindGameObjectsWithTag("UI");
        if(canvas.Length > 1)
        {
            Destroy(canvas[1]);
        }
       DontDestroyOnLoad(canvas[0]);
   }

    void Update()
    {
        playerLevelText.text = "Player Level: " + level;

        playerexperienceText.text = "EXP: " + experience;
        currentLevelText.text = "Current Level: " + currentLevel;
    }

    public void PlayerLevelUp()
    {
        level += 1;
    }

    public void PlayerLevelDown()
    {
        level -= 1;
    }

   

    public void PlayerexperienceUp()
    {
        experience += 1;
    }

    public void PlayerexperienceDown()
    {
        experience -= 1;
    }

    public void NextLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
        LoadLevel();
    }

    public void PreviousLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
        LoadLevel();
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }
}
