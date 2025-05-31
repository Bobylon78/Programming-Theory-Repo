using System.Collections.Generic;
using UnityEngine;

public class SolarSystemManager : MonoBehaviour
{
    
    [SerializeField] private List<Astre> tousLesAstres;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Astre astre in tousLesAstres)
        {
            astre.CalculerPosition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ABSTRACTION
        foreach (Astre astre in tousLesAstres)
        {
            astre.Rotate();
            astre.Move();
        }
    }
}
