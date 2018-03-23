using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

    private UISlider uiSlider;
    private string sceneName = string.Empty;


	// Use this for initialization
	void Start () {
        uiSlider = transform.GetComponent<UISlider>();
        StartCoroutine(LoadingScene());
    }
	
	// Update is called once per frame
	void Update () {
		
        
        //SceneManager.LoadSceneAsync

	}

   public IEnumerator LoadingScene()
    {
        
        int toProgress;
        float disPlayProgess = 0;
        AsyncOperation asynsOne = SceneManager.LoadSceneAsync(1);
        asynsOne.allowSceneActivation = false;
        while (asynsOne.progress < 0.9f)
        {
            toProgress = (int)asynsOne.progress ;

            //for (int i = 0; i < 1; i++)
            //{
            //    disPlayProgess += 0.03f;
            //    SetLoadingSlider(disPlayProgess);
            //    yield return new WaitForEndOfFrame();
            //}
            while (disPlayProgess < toProgress)
            {
                disPlayProgess += 0.002f;
                SetLoadingSlider(disPlayProgess);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForEndOfFrame();
           // print(3243);
        }
        toProgress = 1;
        while (disPlayProgess < toProgress)
        {
            //print(5346);
            disPlayProgess += 0.002f;
            SetLoadingSlider(disPlayProgess);
            yield return new WaitForEndOfFrame();
        }

        asynsOne.allowSceneActivation = true;
       // print("fh44y6");
    }

    public void SetLoadingSlider(float progress)
    {
        uiSlider.value = progress;
    }

}
