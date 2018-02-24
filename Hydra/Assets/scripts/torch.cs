using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torch : MonoBehaviour {

    public GameObject blueTorch;

	void OnMouseDown() {
        Game.current.chestUnlocked = true;
        if (blueTorch != null)
        {
            blueTorch.transform.position = transform.position;
            GameObject.Destroy(this.gameObject);
        }
	}
}
