using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;

    [SerializeField]
    private float bounceSpeed = 2.0f;

    [SerializeField]
    AudioClip bounceSound;
    [SerializeField]
    AudioClip goalSound;

    UI ui;

    private float startSpeed = 0;
    private float xDirection = 0;
    private float yDirection = 0;
    private int[] directions = { -1, 1 };

    // Start is called before the first frame update
    void Start()
    {
        startSpeed = speed;
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        RandomDirection();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * new Vector3(xDirection, yDirection, 0) * speed);

        if (transform.position.x >= 6.9f)
        {
            GetComponent<AudioSource>().PlayOneShot(goalSound);
            ui.UpdateLeftScore();
            ResetBall();
            RandomDirection();
        }

        if(transform.position.x <= -6.9f)
        {
            GetComponent<AudioSource>().PlayOneShot(goalSound);
            ui.UpdateRightScore();
            ResetBall();
            RandomDirection();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            xDirection *= -1;
            speed += bounceSpeed;
        }
        else
        {
            yDirection *= -1;
        }
        GetComponent<AudioSource>().PlayOneShot(bounceSound);
    }

    private void RandomDirection()
    {
        xDirection = directions[Mathf.RoundToInt(Random.Range(0, 2))];
        yDirection = directions[Mathf.RoundToInt(Random.Range(0, 2))];
    }

    private void ResetBall()
    {
        transform.position = Vector3.zero;
        speed = startSpeed;
    }
}