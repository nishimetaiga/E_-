using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseScene : MonoBehaviour
{

	[SerializeField]
	//　ポーズした時に表示するUIのプレハブ
	private GameObject pauseUIPrefab;
	//　ポーズUIのインスタンス
	private GameObject pauseUIInstance;

	[SerializeField]
	// ポーズした時に表示するタイトルへ戻るボタンのプレハブ
	private GameObject goTitleButtonPrefab;
	// タイトルへ戻るボタンのインスタンス
	private GameObject goTitleButtonInstance;

	// Update is called once per frame
	void Update()
	{
		
		if (Input.GetKeyDown("joystick button 7"))
		{
			
			Debug.Log("button7");
			Invoke("ChangeScene", 0.1f);

			{
				if (pauseUIInstance == null)
				{
					pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
					goTitleButtonInstance = GameObject.Instantiate(goTitleButtonPrefab, GameObject.Find("Canvas").transform);
					Time.timeScale = 0f;
				}
				else
				{
					Destroy(pauseUIInstance);
					Destroy(goTitleButtonInstance);
					Time.timeScale = 1f;
				}
			}
		}

		if (Input.GetKeyDown("joystick button 0"))
        {
			Debug.Log("button0");

			if (goTitleButtonInstance != null)
			{
				GoTitleScene();
			}
		}
	}
	void GoTitleScene()
	{
		Destroy(pauseUIInstance);
		Destroy(goTitleButtonInstance);
		Time.timeScale = 1f;
		SceneManager.LoadScene("TitleScene");
	}
}