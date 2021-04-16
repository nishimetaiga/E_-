using UnityEngine;
using System.Collections;

public class PauseScene : MonoBehaviour
{

	[SerializeField]
	//　ポーズした時に表示するUIのプレハブ
	private GameObject pauseUIPrefab;
	//　ポーズUIのインスタンス
	private GameObject pauseUIInstance;

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
					Time.timeScale = 0f;
				}
				else
				{
					Destroy(pauseUIInstance);
					Time.timeScale = 1f;
				}
			}
		}
	}
}