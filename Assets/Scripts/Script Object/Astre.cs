using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Astre : MonoBehaviour
{
    [SerializeField] private string nom;
    [SerializeField] private float masse;
    [SerializeField] private float rayon;
    [SerializeField] private float ditanceOrbitalAU;
    [SerializeField] private float angle;
    [SerializeField] private string couleur;
    [SerializeField] private float vitesseOrbital;
    [SerializeField] private float vitesseRotation;
    [SerializeField] private string type;
    [SerializeField] private Transform centreOrbital;
    [SerializeField] private GameObject prefab;

    public string Nom => nom;
    public float Masse => masse;
    public float Rayon => rayon;
    public float DitanceOrbitalAU => ditanceOrbitalAU;
    public float Angle => angle;
    public string Couleur => couleur;
    public float VitesseOrbital => vitesseOrbital;
    public float VitesseRotation => vitesseRotation;
    public string Type => type;
    public Transform Center => centreOrbital;
    public GameObject Prefab => prefab;

    public virtual void CalculerPosition()
    {
        float distanceUnity = DitanceOrbitalAU * 10f;
        float angle = Angle * Mathf.Deg2Rad;
        Vector3 positionRelative = new Vector3(Mathf.Cos(angle) * distanceUnity, 0, Mathf.Cos(angle) * distanceUnity);
        transform.position = positionRelative + Center.position;
    }
    public virtual void Rotate()
    {
        transform.Rotate(Vector3.up, vitesseRotation *  Time.deltaTime);
    }
    public virtual void Move()
    {
        transform.RotateAround(centreOrbital.position, Vector3.up, vitesseOrbital * Time.deltaTime);
    }
    
}
