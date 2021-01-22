using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;

    [SerializeField]
    private KeyCode up;

    [SerializeField]
    private KeyCode down;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(up) && transform.position.y <= 3.2f)
        {
            transform.Translate(Time.deltaTime * speed * Vector3.up);
        }

        if (Input.GetKey(down) && transform.position.y >= -3.2f)
        {
            transform.Translate(Time.deltaTime * speed * Vector3.down);
        }
    }
}