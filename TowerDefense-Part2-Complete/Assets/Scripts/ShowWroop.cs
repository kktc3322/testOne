using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWroop : MonoBehaviour {

    private GameObject ShowObj;
    private GameObject showObjOne;
    public  int index = 0;

    public static List<GameObject> list = new List<GameObject>();
    // Use this for initialization
	void Start () {
        UIEventListener.Get(transform.gameObject).onClick = _buttoned;
        ShowObj = Resources.Load<GameObject>("wroop") as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void _buttoned(GameObject go)
    {

        //index += 1;
        //print(index);
        GameObject ko = GameObject.Find("wroop(Clone)");
      
        if (GameObject.Find("wroop(Clone)"))
        {
            print(true);
        }
        if (ko==null)
        {
            if (ShowObj != null)
            {
                showObjOne = (GameObject)Instantiate(ShowObj, transform.position, Quaternion.identity);
                showObjOne.transform.parent = transform;
                showObjOne.transform.localScale = Vector3.one;
                list.Add(showObjOne);
            }

        }

        else 
        {
            
             Destroy(ko.gameObject);
            //if (list[0] != null)
            //{
            //    list[0].SetActive(false);
            //}

            // list.Remove(list[0]);
            //list.Clear();
            // index = 1;

            //Debug.LogError("don't find the gameobject");
        }
        //else if (list.Count > 0 && index == 1)
        //{
        //    list[0].transform.position = transform.position;
        //    list[0].SetActive(true);
        //    index = 0;
        //}
        
       // ShowObj.transform.rotation = Quaternion.Euler();
    }
}
