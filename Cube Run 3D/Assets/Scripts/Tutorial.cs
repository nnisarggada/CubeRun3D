using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public GameObject TutorialUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
		{
            TutorialUI.SetActive(false);
		}

        if (Input.anyKey)
		{
            TutorialUI.SetActive(false);
        }
    }
}
