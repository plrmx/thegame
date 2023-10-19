using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    IEnumerator SceneChange()
    {
        
        yield return new WaitForSeconds(20.5f);
        SceneManager.LoadScene("CutScene_2");

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
       			 SceneManager.LoadScene("CutScene_2");
		}
    }
}
