using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject _enemy;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (_enemy == null) {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            int idx = Random.Range(1, 5);
            int siteX = 0;
            int siteZ = 0;
            switch (idx) {
                case 1:
                    siteX = Random.Range(-5, -60);
                    siteZ = Random.Range(-15,20);
                    break;
                case 2:
                    siteX = Random.Range(-15, -65);
                    siteZ = Random.Range(-35, -60);
                    break;
                case 3:
                    siteX = Random.Range(15, 60);
                    siteZ = Random.Range(-35, -60);
                    break;
                case 4:
                    siteX = Random.Range(60, -60);
                    siteZ = Random.Range(45, 70);
                    break;
                default:
                    siteX = Random.Range(-5, -60);
                    siteZ = Random.Range(-15, 20);
                    break;
            }
            _enemy.transform.position = new Vector3(siteX, 0.5f, siteZ);
            float angle = Random.Range(0,360);
            _enemy.transform.Rotate(0,angle,0);
        }	
	}
}
