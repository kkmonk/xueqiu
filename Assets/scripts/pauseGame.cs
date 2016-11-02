using UnityEngine;
using System.Collections;

public class testui : MonoBehaviour {

   public bool IsGamePaused;
	public Texture start;
	public Texture play;

   
   void Start()
   {
       PauseGame();
   }
   
   void Update()
   {
       if (Input.GetKey(KeyCode.Escape))
       {
           PauseGame();
       }
   }
   void OnGUI()
   {
       if (!IsGamePaused)
           return;
       ///自动布局，按照区域
       GUILayout.BeginArea(new  Rect((Screen.width - 100)/2, (Screen.height - 200)/2, 100, 200));
       ///横向
       GUILayout.BeginVertical();
       if (IsGamePaused)
       {
			if(GUILayout.Button(start, GUILayout.Height(50)))
           {
               StartGame();
               //enabled = false;
           }
       }      
       if(GUILayout.Button("退出游戏", GUILayout.Height(50)))
       {
           //在Android上可以，IOS上没试
           //Debug.Log("Exit");
           Application.Quit();
       }
		GUILayout.Button(play, GUILayout.Height(50));
       GUILayout.EndVertical();
       GUILayout.EndArea();
   }
   
   void StartGame()
   {
       IsGamePaused = false;
       Time.timeScale = 1;
       //Debug.Log("Start Game" + Time.fixedTime);
   }
   
   void PauseGame()
   {
       IsGamePaused = true;
       Time.timeScale = 0;
       //Debug.Log("Pause Game");
   }

}
