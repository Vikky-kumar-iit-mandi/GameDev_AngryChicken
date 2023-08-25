
using System.ComponentModel;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class level_manager : MonoBehaviour
{
    private enemy[] No_of_enemies;
    public GameObject COMPLETE;
    public GameObject background;
    public GameObject level_grid;
    public GameObject next;
    public GameObject victorymusic;
    public GameObject levelmusic;
    float bird_wait_time;
    public void Home_Button (string Home)
    {
        SceneManager.LoadScene(Home);
    }
    
    void OnEnable() {
        No_of_enemies = FindObjectsOfType<enemy>();
 
    
        COMPLETE.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
        level_grid.gameObject.SetActive(false);
        next.gameObject.SetActive(false);
        victorymusic.gameObject.SetActive(false);
        levelmusic.gameObject.SetActive(true);
    }
    void Update()
    {
        
        foreach (enemy Enemies in No_of_enemies)
        {
            if (Enemies != null)
            {
                return;
            }
        }
        if (bird_wait_time > 3)
        {


            COMPLETE.gameObject.SetActive(true);
            background.gameObject.SetActive(true);
            level_grid.gameObject.SetActive(true);
            next.gameObject.SetActive(true);
            victorymusic.gameObject.SetActive(true);
            levelmusic.gameObject.SetActive(false);
        }
        bird_wait_time += Time.deltaTime;
    }
}
