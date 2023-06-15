using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SelectiveEvolution : MonoBehaviour
{
    private int[] starterCreature = new int[] { 20, 20, 20, 20 };
    private List<int[]> currentGeneration = new List<int[]>();
    private int firstDesiredTraitN = 0;
    private int firstDesiredTraitValue = 50;
    private int secondDesiredTraitN = 1;
    private int secondDesiredTraitValue = 50;
    private int[,] desiredTraits = new int[2,2];
    private int[] selectedCreaturesIndex = new int[] { 0, 0 };
    private int nowSelecting = 0;
    [SerializeField] private TextMeshProUGUI selectedCreature1Text;
    [SerializeField] private TextMeshProUGUI selectedCreature2Text;
    [SerializeField] private TextMeshProUGUI selectCreatureText;


    void Start()
    {
        desiredTraits[0,0] = firstDesiredTraitN;
        desiredTraits[0,1] = firstDesiredTraitValue;
        desiredTraits[1,0] = secondDesiredTraitN;
        desiredTraits[1,1] = secondDesiredTraitValue;
        NextGeneration(starterCreature, starterCreature);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            NextGeneration(currentGeneration[selectedCreaturesIndex[0]], currentGeneration[selectedCreaturesIndex[1]]);
        }
    }

    private void NextGeneration(int[] parent1, int[] parent2) {
        currentGeneration = new List<int[]>();
        for (int childN = 0; childN < 5; childN++) {
            int[] child = new int[] {0, 0, 0, 0};

            // random mix of parents traits
            int[] dominantTraits = new int[] { 0, 0, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                if (Random.Range(0, 1) == 0) {
                    dominantTraits[i] = parent1[i];
                }
                else {
                    dominantTraits[i] = parent2[i];
                }
            }

            // mutate
            int traitN = 0;
            foreach (int trait in dominantTraits) {
                child[traitN] = trait + Random.Range(-10, 10);
                if (child[traitN] < 0) {
                    child[traitN] = 0;
                }
                traitN++;
            }
            currentGeneration.Add(child);
        }
        PrintGeneration(currentGeneration);
        nowSelecting = 0;
    }

    private string PrintTraits(int[] creature) { 
        string traitsString = "";
        foreach (int trait in creature) {
            traitsString += trait + " ";
        }
        return traitsString;
    }

    private void PrintGeneration(List<int[]> generation) {
        Debug.Log("Generation: ");

        int creatureN = 1;
        foreach (int[] creature in generation) {
            Debug.Log(creatureN + " " + PrintTraits(creature) + EvaluateCreature(creature));
            creatureN++;
        }
    }

    private int EvaluateCreature(int[] creature) {
        int score = 0;
        List<int> distances = new List<int>();
        int firstDistanceToDesiredTrait = desiredTraits[0,1] - creature[desiredTraits[0,0]];
        distances.Add(100 - Mathf.Abs(firstDistanceToDesiredTrait));
        int secondDistanceToDesiredTrait = desiredTraits[1, 1] - creature[desiredTraits[1, 0]];
        distances.Add(100 - Mathf.Abs(secondDistanceToDesiredTrait));
        score = Mathf.RoundToInt((float)distances.Average());
        return score;
    }

    public void SelectCreature(int creatureIndex) {
        selectedCreaturesIndex[nowSelecting] = creatureIndex;
        if (nowSelecting == 0) {
            selectedCreature1Text.text = "Selected creature: " + (creatureIndex + 1);
        } else {
            selectedCreature2Text.text = "Selected creature: " + (creatureIndex + 1);
        }
        nowSelecting++;
        if (nowSelecting > 1) {
            nowSelecting = 0;
        }
        selectCreatureText.text = "Select creature " + (nowSelecting + 1);
    }
}
