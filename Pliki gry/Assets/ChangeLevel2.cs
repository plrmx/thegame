using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelTwo : MonoBehaviour
{
    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("SampleScene"); 

    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneChange());

    }

    // Update is called once per frame
    void Update()
    {
        if(UnityEngine.Input.GetKeyDown("space")){
			        SceneManager.LoadScene("SampleScene"); 
		}
    }
}
