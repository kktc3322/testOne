using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatTrow : MonoBehaviour {


    public GameObject[] obj;
    public GameObject moddleSprite;
    private GameObject CreatObj;
    public UIEventListener[] allWarEvent;
    //public GameObject[] allAtack;

    private GameManagerBehavior gameManager;

    // Use this for initialization
    void Start () {
        UIEventListener.Get(transform.gameObject).onClick = _buttonedToTrow;
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
        foreach (UIEventListener e in allWarEvent)
        {
            e.onClick += _buttonedToTrow;
        }
    }

   // private bool canPlaceMonster()
    //{

       
        //int cost = obj.GetComponent<MonsterData>().levels[0].cost;//需要花费的金币
       // return CreatObj == null && gameManager.Gold >= cost;//判断金币需求
    //}

    // Update is called once per frame
    void Update () {
		
	}

    void _buttonedToTrow(GameObject go)
    {
        if (go.transform.name.Equals("Ataack1"))
        {
            int cost = obj[0].GetComponent<MonsterData>().levels[0].cost;

            if (GameManagerBehavior.Gold>=cost&& CreatObj==null)
            {
                CreatObj = (GameObject)Instantiate(obj[0], moddleSprite.transform.position, Quaternion.identity);
                CreatObj.transform.parent = moddleSprite.transform.parent.parent;
                CreatObj.transform.localScale = Vector3.one;
                Destroy(moddleSprite.transform.parent.gameObject);
            }

            
        }
        
    }
}
