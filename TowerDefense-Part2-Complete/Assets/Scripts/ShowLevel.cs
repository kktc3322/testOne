using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowLevel : MonoBehaviour {


	// Use this for initialization
	void Start () {
        UIEventListener.Get(transform.gameObject).onClick = SlodGold;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SlodGold(GameObject g)
    {
        SceneManager.LoadSceneAsync(1);
    }
    
}
