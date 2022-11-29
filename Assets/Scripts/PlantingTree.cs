using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingTree : MonoBehaviour
{
    public GameObject tree;

    // Start is called before the first frame update
    void Start()
    {
        tree.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Planted()
    {
        Debug.Log("Planted");
        tree.SetActive(true);
    }
}
