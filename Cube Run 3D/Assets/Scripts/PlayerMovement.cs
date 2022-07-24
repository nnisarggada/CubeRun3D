using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public int fall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > Screen.width / 2)
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            else
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < 0f)
        {
            fall++;
        }
        else
		{
            fall = 0;
        }
        if (fall == 1)
		{
            Handheld.Vibrate();
            FindObjectOfType<AudioManager>().Play("Death");
            FindObjectOfType<GameManager>().CheckRevive();
        }
        if (rb.position.y >= 1f)
		{
            rb.position = new Vector3(rb.position.x, 1f, rb.position.z);
            Quaternion newQuaternion = new Quaternion();
            newQuaternion.Set(0, 0, 0, 1);
            newQuaternion = newQuaternion.normalized;
            rb.rotation = newQuaternion;
        }
    }
}
