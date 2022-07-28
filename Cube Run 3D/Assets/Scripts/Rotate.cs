using UnityEngine;

public class Rotate : MonoBehaviour
{
    public int spin;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.value <= 0.5){
            spin = 1;
        }
        else {
            spin = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0,spin * 120 * Time.deltaTime * Time.timeScale, 0));
    }
}
