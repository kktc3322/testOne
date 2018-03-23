using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour {

    public UILabel[] uilabel;
    public UI2DSprite[] uisprite;
    public static int index = 1;
    private SpawnEnemy spawnEnemy = new SpawnEnemy();
    

	// Use this for initialization
	void Start ()
    {
        uilabel[0].text = GameManagerBehavior.Gold.ToString();
        UIEventListener.Get(transform.gameObject).onClick = buttonEvent;

    }
	
	// Update is called once per frame
	void Update ()
    {
        

	}

    void buttonEvent(GameObject go)
    {

        SceneManager.LoadSceneAsync(index);
    }

}
