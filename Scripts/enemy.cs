
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject Destroy_Effect;
    public GameObject AAU;
    public Rigidbody2D bird;
    private float Bird_Wait_Time;
    // Start is called before the first frame update

    void OnCollisionEnter2D(Collision2D Target)
    {
        if (bird.velocity.magnitude > 0.5 || Bird_Wait_Time < 2.5)
        {
            if (Target.collider.GetComponent<bird>())
            {
                Instantiate(Destroy_Effect, transform.position, Quaternion.identity);
                AAU.gameObject.SetActive(false);
                AAU.gameObject.SetActive(true);
                Destroy(gameObject);


            }
            else if (Target.contacts[0].normal.y <= 0.1f)
            {
                Instantiate(Destroy_Effect, transform.position, Quaternion.identity);
                AAU.gameObject.SetActive(false);
                AAU.gameObject.SetActive(true);
                Destroy(gameObject);
            }
        }
        else
        {
            Bird_Wait_Time += Time.deltaTime;
        }

    }
}
