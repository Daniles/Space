using UnityEngine;
using System.Collections;

public class DefensesSpawn : MonoBehaviour {

    public float squareSize = 0.3f;
    public GameObject defensePrefab;
	// Use this for initialization
	void Start () {
	    for(int i = 1; defensePrefab; i++)
        {
            Transform defense = transform.FindChild("Defense" + i.ToString());
            if (!defense) break;
            for (int j = -6; j < 6; j++)
            {
                Instantiate(defensePrefab, new Vector3(defense.position.x + squareSize * j, defense.position.y + squareSize/2, defense.position.z), Quaternion.identity);
            }
            for (int j = -6; j < 6; j++)
            {
                (Instantiate(defensePrefab, new Vector3(defense.position.x + squareSize * j, defense.position.y - squareSize/2, defense.position.z), Quaternion.identity) as GameObject).transform.SetParent(defense);
            }
        }
	}

}
