using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardControl : MonoBehaviour {

  public GameObject prefabWhiteField;
  public GameObject prefabBlackField;

  [Range(5,11)]
  public int fieldSize = 7;
  private static GameObject[,] playField;

	void Awake () {
    playField = new GameObject[fieldSize,fieldSize];
    // 6x6 Feld erzeugen
    for (int x = 0; x < fieldSize; x++){
      for (int z = 0; z < fieldSize; z++){
        if ((z+x) % 2 == 0){
          playField[x,z] = GameObject.Instantiate(prefabWhiteField, new Vector3(x, 0, z), Quaternion.identity, gameObject.transform);
        }
        else {
          playField[x,z] = GameObject.Instantiate(prefabBlackField, new Vector3(x, 0, z), Quaternion.identity, gameObject.transform);
        }
      }
    }
	}

  public static GameObject[,] getField(){
    return playField;
  }
}
