using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnNPC : MonoBehaviour {

    public GameObject NPCPrefab;
    public int quantity = 0;
    private Transform NPCPlace;

    public GameObject GameResult;
    // Use this for initialization
    void Start () {
        NPCPlace = GameObject.Find("NPCPlace").transform;
        for(int i = 1; true; i++)
        { 
            Transform NPCPlaceUnit = NPCPlace.FindChild("Place" + i.ToString());
            if (!NPCPlaceUnit) break;
            quantity++;
            (Instantiate(NPCPrefab, NPCPlaceUnit.position, Quaternion.identity) as GameObject).transform.parent = gameObject.transform;
        }
	}
	
    public void NPCDestroy ()
    {
        quantity--;
        if (quantity <= 0)
        {
            GameResult.GetComponent<Text>().text = "YOU WIN";
            GameResult.SetActive(true);
            Time.timeScale = 0;
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
