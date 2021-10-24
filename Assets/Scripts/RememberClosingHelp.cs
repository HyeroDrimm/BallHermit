using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberClosingHelp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("OpenedOnce", 0) == 0)
        {
            gameObject.SetActive(true);
            PlayerPrefs.SetInt("OpenedOnce", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
