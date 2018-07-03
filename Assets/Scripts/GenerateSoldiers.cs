using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSoldiers : MonoBehaviour {

  public GameObject prefabSoldier;
  public Material rockMaterial;
  public Material paperMaterial;
  public Material scissorMaterial;

  public bool firstPlayer;

  private GameObject[,] playField;
  private int fieldSize;
  private GameObject soldier;

	// Use this for initialization
	void Start () {
    playField = BoardControl.getField();
    fieldSize = Mathf.RoundToInt(Mathf.Sqrt(playField.Length));
    if (GameObject.FindGameObjectsWithTag("player").Length < 2){
      firstPlayer = true;
    } else {
      firstPlayer = false;
    }
    // Spieler 1 kriegt Reihe 1,2
    // Spieler 2 kriegt Reihe fieldSize-1, fieldSize-2
    for (int x = 0; x < fieldSize; x++){
      for (int z = 0; z < 2; z++){
        if (firstPlayer){
          soldier = GameObject.Instantiate(prefabSoldier, new Vector3(x, 0, z), Quaternion.identity);//, gameObject.transform);
        }
        else {
          soldier = GameObject.Instantiate(prefabSoldier, new Vector3(x, 0, fieldSize - z - 1), Quaternion.identity);//, gameObject.transform);
        }
        // set Color
        MeshRenderer renderer = soldier.GetComponentInChildren<MeshRenderer>();
        int choice = Random.Range(1,4);
        switch (choice){
          case 1:
            renderer.material = rockMaterial;
            break;
          case 2:
            renderer.material = paperMaterial;
            break;
          case 3:
            renderer.material = scissorMaterial;
            break;
          }
      }
    }


	}

	// Update is called once per frame
	void Update () {

	}
}
