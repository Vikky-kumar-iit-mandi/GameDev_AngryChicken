using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bird : MonoBehaviour
{
    public Vector3 Initial_Position;
    public int Bird_Speed;
    public string Scene_Name;
    private bool Bird_Enable_Time;
    private float Bird_Wait_Time;
    public float max_dist;
    private enemy[] No_of_enemies;
    private bool check;
    bool faltu;
    public GameObject gurrana;
    public GameObject udna;
    public GameObject RESTART;
    Rigidbody2D rb;

    public void Awake()
    {
        Initial_Position = transform.position;
        rb = GetComponent<Rigidbody2D>();
        check = false;
        
    }
    public void OnMouseDown()
    {
        if (check == false)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            gurrana.gameObject.SetActive(true);

            rb.gravityScale = 1;
            
        }
    

    }

    public void OnMouseUp()
    {
        if (check == false )
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            Bird_Enable_Time = true;
            check = true;
            gurrana.gameObject.SetActive(false);
            udna.gameObject.SetActive(true);
        }
    }

    public void OnMouseDrag()
    {
        if (check == false)
        {
            
            Vector3 DragPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(DragPosition, Initial_Position) > max_dist)
            {
                transform.position = Initial_Position+(DragPosition-Initial_Position).normalized*max_dist;

            }
            else
            {
                transform.position = new Vector3(DragPosition.x, DragPosition.y);
            }
        }



        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        udna.gameObject.SetActive(false);
    }
    


    void Update()
    {
        

            if (Bird_Enable_Time && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.5)
            {
                Bird_Wait_Time += Time.deltaTime;
                No_of_enemies = FindObjectsOfType<enemy>();
        }

            if (Bird_Wait_Time > 3 )
            {
            foreach (enemy Enemies in No_of_enemies)
            {
                if (Enemies != null)
                {   
                    RESTART.gameObject.SetActive(true);
                    if (Bird_Wait_Time > 5)
                    {


                        SceneManager.LoadScene(Scene_Name);
                    }
                    Bird_Wait_Time += Time.deltaTime;
                }
            }
            
            }
        }
    }


    

