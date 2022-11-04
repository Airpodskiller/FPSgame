using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReacticeTarget : MonoBehaviour {
    public void ReactToHit() {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null) {
            WanderingAI.setSpeed();
            behavior.setAlive(false);
        }
        StartCoroutine(Die());
    }
    private IEnumerator Die() {
        this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
