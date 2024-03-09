using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public int GEMS = 0;

    public List<GameObject> GEMSList = new List<GameObject>();
    public List<GameObject> ALLGEMS = new List<GameObject>();
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Gems")) {
            GEMS++;
            GEMSList.Add(collision.gameObject);
        }
    }

    private void Update() {
        foreach (GameObject obj in GEMSList) {
            if (obj != null) {
                obj.SetActive(false);
            }
        }
    }

    public void Return() {
        foreach (GameObject obj in ALLGEMS) {
            if (!GEMSList.Contains(obj)) {
                obj.SetActive(true);
            }
        }
    }
}