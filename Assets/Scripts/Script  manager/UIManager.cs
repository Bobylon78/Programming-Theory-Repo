using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public Camera mainCamera;
    public Transform currentTarget;
    public float zoomDistance = 1f;
    public float zoomSpeed = 1f;
    public Vector3 offsetDirection = new Vector3(1f, 0.5f, -1f);
    private Vector3 targetPosition;
    public bool isZooming = false;

    public GameObject panelInfo;
    public TMP_Text nomText;
    public TMP_Text masseText;
    public TMP_Text rayonText;
    public TMP_Text colorText;
    public TMP_Text vitesseOrbitalText;
    public TMP_Text vitesseRotationText;
    public TMP_Text typeText;

    private Astre astreSelectionne;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
      
        
    }
    // Update is called once per frame
    void Update()
    {
        if (isZooming)
        {
            mainCamera.transform.position = Vector3.Lerp(targetPosition, targetPosition, zoomSpeed *Time.deltaTime);
            mainCamera.transform.LookAt(currentTarget);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Astre astre = hit.collider.GetComponent<Astre>();
                if (astre != null)
                {
                    ZoomToAstre(astre.transform);
                    AfficherInfo(astre);

                }
            }
        }
    }
    public void ZoomToAstre (Transform astre)
    {
        Debug.Log("ALERTE");
        currentTarget = astre;
        Vector3 offset = offsetDirection.normalized * zoomDistance;
        targetPosition = astre.position + offset;
        isZooming = true;
    }
        

    public void AfficherInfo(Astre astre)
    {
        astreSelectionne = astre;
        panelInfo.SetActive(true);
        nomText.text = astre.Nom;
        masseText.text = "Masse : " + astre.Masse + "kg";
        rayonText.text = "Diamètre : " + (astre.Rayon*2) + "km";
        colorText.text = "Couleur : " + astre.Couleur;
        vitesseOrbitalText.text = "Révolution Orbital : " + astre.VitesseOrbital + "Jours/Année" ;
        vitesseRotationText.text = "Rotation : " + astre.VitesseRotation + "Heures/Jours";
        typeText.text = astre.Type;
    }


}
