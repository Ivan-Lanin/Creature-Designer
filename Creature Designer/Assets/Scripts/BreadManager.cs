using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadManager : MonoBehaviour
{
    [SerializeField] private GameObject[] parents;
    [SerializeField] private GameObject creaturePrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Bread();
        }
    }


    private void Bread()
    {
        GameObject child = Instantiate(creaturePrefab, transform.position, Quaternion.identity);
        Creature childTraits = child.GetComponent<Creature>();
        int childTrait1 = parents[Random.Range(0, 2)].GetComponent<Creature>().trait1 + Random.Range(-2,2);
        int childTrait2 = parents[Random.Range(0, 2)].GetComponent<Creature>().trait2 + Random.Range(-2, 2);
        int childTrait3 = parents[Random.Range(0, 2)].GetComponent<Creature>().trait3 + Random.Range(-2, 2);
        childTraits.SetTraitsFromParrents(childTrait1, childTrait2, childTrait3);
    }
}
