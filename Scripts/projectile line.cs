using UnityEngine;

public class trajectoryline : MonoBehaviour
{
    public float power = 5f;

    LineRenderer lr;
    Rigidbody2D rb;

    Vector2 startDragPos;
    bool check;
    bool faltu;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        check = false;
        faltu = false;
    }

    void Update()
    {
        if (check == false)
        {
            if (Input.GetMouseButtonDown(0))
                startDragPos = transform.position;

            if (Input.GetMouseButton(0))
            {
                lr.enabled = true;

                Vector2 endDragPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 _velocity = -(endDragPos - startDragPos) * power;

                Vector2[] trajectory = Plot(rb, startDragPos, _velocity, 500);
                if (Vector3.Distance(endDragPos, startDragPos) > 5)
                {
                    transform.position = startDragPos + (endDragPos - startDragPos).normalized * 5;

                }
                else
                {
                    transform.position = new Vector3(endDragPos.x, endDragPos.y);

                }

                lr.positionCount = trajectory.Length;

                Vector3[] positions = new Vector3[trajectory.Length];

                for (int i = 0; i < trajectory.Length; i++)
                {
                    positions[i] = trajectory[i];
                }

                lr.SetPositions(positions);
            }
            else
            {
                lr.enabled = false;
            }

            if (Input.GetMouseButtonUp(0))
            {   
                    Vector2 endDragPos = transform.position;
                    Vector2 _velocity = -(endDragPos - startDragPos) * (1 + power);
                    check = true;

                   rb.velocity = _velocity;
                
            }
        }
    }

    public Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int steps)
    {
        Vector2[] results = new Vector2[steps];

        float timestep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * timestep * timestep;

        float drag = 1f - timestep * rigidbody.drag;
        Vector2 moveStep = velocity * timestep;

        for (int i = 0; i < steps; i++)
        {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }

        return results;
    }
}