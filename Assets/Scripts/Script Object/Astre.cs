using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Astre : MonoBehaviour
{
    //HERITAGE
    [SerializeField] private string nom;
    [SerializeField] private string masse;
    [SerializeField] private string diametre;
    [SerializeField] private float ditanceOrbitalAU;
    [SerializeField] private float angle;
    [SerializeField] private string couleur;
    [SerializeField] private float vitesseOrbital;
    [SerializeField] private string vitesseOrbitalReel;
    [SerializeField] private float vitesseRotation;
    [SerializeField] private string vitesseRotationReel;
    [SerializeField] private string type;
    [SerializeField] private Transform centreOrbital;
    [SerializeField] private GameObject prefab;


    public string Nom => nom;
    public string Masse => masse;
    public string Diametre => diametre;
    public float DitanceOrbitalAU => ditanceOrbitalAU;
    public float Angle => angle;
    public string Couleur => couleur;
    public float VitesseOrbital => vitesseOrbital;
    public float VitesseRotation => vitesseRotation;
    public string Type => type;
    public Transform Center => centreOrbital;
    public GameObject Prefab => prefab;
    public string VitesseOrbitalReel => vitesseOrbitalReel;
    public string VitesseRotationReel => vitesseRotationReel;

    public virtual void CalculerPosition()
    {
        float distanceUnity = DitanceOrbitalAU * 10f;
        float angle = Angle * Mathf.Deg2Rad;
        Vector3 positionRelative = new Vector3(Mathf.Cos(angle) * distanceUnity, 0, Mathf.Cos(angle) * distanceUnity);
        transform.position = positionRelative + Center.position;
        TrailRenderer trail = GetComponent<TrailRenderer>();
        if (trail != null)
        {
            trail.enabled = true;
        }
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
