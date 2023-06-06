using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] private bool isFirstGeneration = false;
    [SerializeField] private Color color;
    [SerializeField] private GameObject[] legsFront;
    [SerializeField] private GameObject[] legsBack;
    [SerializeField] private GameObject head;
    [Range(0.0f, 2.0f)]
    [SerializeField] private float legsFrontLength = 1;
    [Range(0.0f, 2.0f)]
    [SerializeField] private float legsBackLength = 1;

    public int trait1 { get; private set; }
    public int trait2 { get; private set; }
    public int trait3 { get; private set; }


    void Start()
    {
        legsFrontLength = legsFront[0].transform.localScale.y;
        legsBackLength = legsBack[0].transform.localScale.y;

        Renderer renderer = head.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", color);

        if (isFirstGeneration) {
            trait1 = Random.Range(0, 11);
            Debug.Log(trait1);
            trait2 = Random.Range(0, 11);
            Debug.Log(trait2);
            trait3 = Random.Range(0, 11);
            Debug.Log(trait3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 2; i++)
        {
            legsFront[i].transform.localScale = new Vector3(legsFront[i].transform.localScale.x, legsFrontLength, legsFront[i].transform.localScale.z);
        }

        for (int i = 0; i < 2; i++)
        {
            legsBack[i].transform.localScale = new Vector3(legsBack[i].transform.localScale.x, legsBackLength, legsBack[i].transform.localScale.z);
        }
    }


    public void SetTraitsFromParrents(int parrentTrait1, int parrentTrait2, int parrentTrait3)
    {
        trait1 = parrentTrait1;
        Debug.Log(trait1);
        trait2 = parrentTrait2;
        Debug.Log(trait2);
        trait3 = parrentTrait3;
        Debug.Log(trait3);
    }
}
