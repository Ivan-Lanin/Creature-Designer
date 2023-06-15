using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime.CompilerServices;

public class CreatureTraits : MonoBehaviour
{
    public enum TraitType {
        Health,
        Speed,
        Strength,
        Intelligence
    }

    [SerializeField] public Dictionary<TraitType, int> thisTraits { get; private set; } = new Dictionary<TraitType, int>()
    {
        {TraitType.Health, 1},
        {TraitType.Speed, 1},
        {TraitType.Strength, 1},
        {TraitType.Intelligence, 1}
    };

    private bool hasDefaultTraits = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InheritFromParents(Dictionary<TraitType, int> parent1, Dictionary<TraitType, int> parent2, Dictionary<TraitType, int> dominantTraits) {
        if (hasDefaultTraits) {
            hasDefaultTraits = false;

        }
    }
}
