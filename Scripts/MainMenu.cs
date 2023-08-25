using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu: MonoBehaviour
{
    public GameObject click;
    
    public void Start_Button(string Start)
    {
        StartCoroutine(Start_Buttonreal(Start));
    }
    public IEnumerator Start_Buttonreal (string Start) 
    {
        click.gameObject.SetActive (true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene (Start);  
    }
    public void Quit_Game()
    {
        Application.Quit ();    
    }
}
