using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

    private Vector3 feederPos;
    private Vector3 nestPos;
    private Rigidbody cretureRb;
    [SerializeField] private Vector3 currentTarget;
    [SerializeField] private float speed = 15f;


    void Start()
    {
        legsFrontLength = legsFront[0].transform.localScale.y;
        legsBackLength = legsBack[0].transform.localScale.y;

        cretureRb = GetComponent<Rigidbody>();
        feederPos = GameObject.Find("Feeder").transform.position;
        nestPos = GameObject.Find("Nest").transform.position;
        StartCoroutine(ChangeTarget(1, feederPos));

        Renderer renderer = head.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", color);

        if (isFirstGeneration) {
            Debug.Log(trait1 + trait2 + trait3);
            SetTraitsFromParrents(Random.Range(0, 11), Random.Range(0, 11), Random.Range(0, 11));
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChangeLegsLength();

        if (currentTarget != Vector3.zero) {
            cretureRb.AddRelativeForce(Vector3.forward * (speed * Time.deltaTime), ForceMode.VelocityChange);
        }
    }


    private void ChangeLegsLength() {
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Feeder" && currentTarget != nestPos) {
            currentTarget = Vector3.zero;
            StartCoroutine(ChangeTarget(5, nestPos));
        }
        else if (other.gameObject.name == "Nest" && currentTarget != feederPos) {
            currentTarget = Vector3.zero;
            StartCoroutine(ChangeTarget(5, feederPos));
        }
    }

    IEnumerator ChangeTarget(int secondsToWait, Vector3 target)
    {
        cretureRb.velocity = Vector3.zero;
        yield return new WaitForSeconds(secondsToWait);
        currentTarget = target;
        cretureRb.transform.LookAt(currentTarget);
    }
}
