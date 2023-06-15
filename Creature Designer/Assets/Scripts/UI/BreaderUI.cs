using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BreaderUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI p1Health;
    [SerializeField] TextMeshProUGUI p2Health;
    [SerializeField] TextMeshProUGUI p1Speed;
    [SerializeField] TextMeshProUGUI p2Speed;
    [SerializeField] TextMeshProUGUI p1Strength;
    [SerializeField] TextMeshProUGUI p2Strength;
    [SerializeField] TextMeshProUGUI p1Intelligence;
    [SerializeField] TextMeshProUGUI p2Intelligence;

    [SerializeField] UnityEngine.UI.Button p1HealthButton;
    ParametersList p1HealthButtonParameters = new ParametersList("Health", 1);
    [SerializeField] UnityEngine.UI.Button p2HealthButton;
    ParametersList p2HealthButtonParameters = new ParametersList("Health", 2);
    [SerializeField] UnityEngine.UI.Button p1SpeedButton;
    ParametersList p1SpeedButtonParameters = new ParametersList("Speed", 1);
    [SerializeField] UnityEngine.UI.Button p2SpeedButton;
    ParametersList p2SpeedButtonParameters = new ParametersList("Speed", 2);


    [SerializeField] GameObject[] healthPointers;
    [SerializeField] GameObject[] speedPointers;

    private Dictionary<string, GameObject[]> dnaEditorPointers = new Dictionary<string, GameObject[]>();


    // Start is called before the first frame update
    void Start()
    {
        dnaEditorPointers.Add("Health", healthPointers);
        dnaEditorPointers.Add("Speed", speedPointers);
        p1HealthButton.onClick.AddListener(() => ChooseDominantTrait(p1HealthButtonParameters.trait, p1HealthButtonParameters.parentN));
        p2HealthButton.onClick.AddListener(() => ChooseDominantTrait(p2HealthButtonParameters.trait, p2HealthButtonParameters.parentN));
        p1SpeedButton.onClick.AddListener(() => ChooseDominantTrait(p1SpeedButtonParameters.trait, p1SpeedButtonParameters.parentN));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseDominantTrait(string element, int parent) {
        if (parent == 0)
        {
            dnaEditorPointers[element][0].gameObject.SetActive(false);
            dnaEditorPointers[element][1].gameObject.SetActive(false);
        }
        else if (parent == 1) {
            dnaEditorPointers[element][0].gameObject.SetActive(true);
            dnaEditorPointers[element][1].gameObject.SetActive(false);
        }
        else {
            dnaEditorPointers[element][0].gameObject.SetActive(false);
            dnaEditorPointers[element][1].gameObject.SetActive(true);
        }
    }
}

internal class ParametersList
{
    public string trait;
    public int parentN;

    public ParametersList(string a, int b)
    {
        trait = a;
        parentN = b;
    }
}