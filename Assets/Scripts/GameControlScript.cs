using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class GameControlScript : MonoBehaviour {

	private GameObject[] listOfObjects;
	private GameObject[] listOfMonsters;
	private GUIStyle style = new GUIStyle();
	private bool firstRun = false;

	string message;
	public int score = 0;

	// Place holders to allow connecting to other objects
	public Transform spawnPoint;
	public GameObject player;

	// Flags that control the state of the game
	private float elapsedTime = 0;
	private bool isRunning = false;
	private bool isFinished = false;

	// So that we can access the controller from this whole script
	private FirstPersonController fpsController;


	// Use this for initialization
	void Start () {
		// Finds the First Person Controller script on the Player
		fpsController = player.GetComponent<FirstPersonController> ();
	
		// Disables controls at the start.
		fpsController.enabled = false;

		score = 0;
	}


	//This resets to game back to the way it started
	private void StartGame()
	{
		elapsedTime = 0;
		isRunning = true;
		isFinished = false;
		
		// Move the player to the spawn point, and allow it to move.
		player.transform.position = spawnPoint.position;
		fpsController.enabled = true;
	}


	// Update is called once per frame
	void Update () {
		// Add time to the clock if the game is running
		if (isRunning) {
			elapsedTime += Time.deltaTime;
		}
	}


	// Runs when the player enters the finish zone
	public void FinishedGame()
	{
		isRunning = false;
		isFinished = true;
		fpsController.enabled = false;
	}

	public void AddScore (int newScoreValue) {
		score += newScoreValue;
	}
	
	//This section creates the Graphical User Interface (GUI)
	void OnGUI() {
		
		if (!isRunning) {
			

			if (isFinished) {
				message = "Medium (m)";
			} else {
				message = "Medium (m)";
			}





			Rect easyButton = new Rect (Screen.width / 2 - 70, Screen.height / 3, 140, 30); //user
			Rect mediumButton = new Rect (Screen.width / 2 - 70, Screen.height / 2, 140, 30);
			Rect hardButton = new Rect (Screen.width / 2 - 70, (Screen.height / 3) * 2, 140, 30); //user

			Rect restartButton = new Rect (Screen.width / 2 - 80, Screen.height / 2, 150, 30);

			if (firstRun == false) {
				if (GUI.Button (easyButton, "Easy (e)") || (Input.GetKeyDown("e"))) {
					//start the game if the user clicks to play

					//listOfMonsters = GameObject.FindGameObjectsWithTag ("monsters");
					//foreach (GameObject t in listOfMonsters) {
					//	t.GetComponent<chase> ().lookDistance = 10;
					//	t.GetComponent<chase> ().walkDistance = 50;
					//}

					CreateBullets.bulletCount = 21;
					chase.walkDistance = 5;
					chase.lookDistance = 10;

					firstRun = true;
					StartGame ();


				}
			}

			if (firstRun == false) {
				if (GUI.Button (mediumButton, message) || (Input.GetKeyDown("m"))) {
					//start the game if the user clicks to play

					CreateBullets.bulletCount = 11;
					chase.walkDistance = 25;
					chase.lookDistance = 30;
					firstRun = true;
					StartGame ();

				}
			}

			if (firstRun == false) {
				if (GUI.Button (hardButton, "Hard (h)") || (Input.GetKeyDown("h"))) {
					//start the game if the user clicks to play


					CreateBullets.bulletCount = 6;
					chase.walkDistance = 125;
					chase.lookDistance = 130;
					firstRun = true;
					StartGame ();

				}
			}


			if (firstRun == true) {
				if (GUI.Button (restartButton, "Press space to Restart") || (Input.GetKeyDown("space"))) {
					SceneManager.LoadScene (sceneName: "Main");
				}
			}
		}
		
		// If the player finished the game, show the final time
		if (isFinished) {
			fpsController.enabled = false;
			GUI.Box (new Rect (Screen.width / 2 - 65, 185, 130, 40), "Your Time Was"); //x,y,width,height
			GUI.Label (new Rect (Screen.width / 2 - 10, 200, 30, 30), ((int)elapsedTime).ToString ());

			GUI.Box (new Rect (Screen.width / 2 - 65, 140, 130, 40), "Your Score Was"); //x,y,width,height
			GUI.Label (new Rect (Screen.width / 2 - 10, 155, 30, 30), ((int)score).ToString ());
		
	

		} else if(isRunning) { // If the game is running, show the current time
			GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "Your Time Is");
			GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 30, 30), ((int)elapsedTime).ToString());
			style.fontSize = 20;
			GUI.Label (new Rect (Screen.width / 10 - 10, Screen.height / 10, 20, 30), (score).ToString (), style);
			GUI.Label (new Rect ((Screen.width / 10) *8, Screen.height / 10, 20, 30), "Bullets: " + (CreateBullets.bulletCount).ToString (), style);
		}
		
	}
}
