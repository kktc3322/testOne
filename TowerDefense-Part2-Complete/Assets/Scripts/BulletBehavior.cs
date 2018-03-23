using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

	public float speed = 20;
	public float damage;
	public GameObject target;
	public Vector3 startPosition;
	public Vector3 targetPosition;

   // public Transform transform;
	private float distance;
	private float startTime;
	
	private GameManagerBehavior gameManager;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		distance = Vector3.Distance (startPosition, targetPosition);
		GameObject gm = GameObject.Find("GameManager");
		gameManager = gm.GetComponent<GameManagerBehavior>();	
	}
	
	// Update is called once per frame
	void Update () {
		// 1 
		float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);
        //print(targetPosition);
       // print(transform.position);
         //Vector3 direction = gameObject.transform.position - target.transform.position;
        //gameObject.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI,new Vector3(0, 0, 1));
        // 2 
        if (gameObject.transform.position.x == targetPosition.x || gameObject.transform.position.y == targetPosition.y)
        {
            if (target != null)
            {
                // 3
                Transform healthBarTransform = target.transform.Find("HealthBarBackground");
                //HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
                UISlider healthBar = healthBarTransform.gameObject.GetComponent<UISlider>();
                healthBar.value -= Mathf.Max(damage, 0);
                //healthBar.currentHealth -= Mathf.Max(damage, 0);
                // 4
                if (healthBar.value <= 0)
                {

                    AudioSource audioSource = target.GetComponent<AudioSource>();
                    audioSource.PlayOneShot(audioSource.clip);
                    //AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                    Destroy(target);

                    GameManagerBehavior.Gold += 50;
                }
            }

            Destroy(gameObject);


        }
        else
        {
            Destroy(gameObject, 1);
        }
        
	}

   
}
