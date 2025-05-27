using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject panelInfo;
    public TMP_Text nomText;
    public TMP_Text masseText;
    public TMP_Text rayonText;
    public TMP_Text colorText;
    public TMP_Text vitesseOrbitalText;
    public TMP_Text vitesseRotationText;
    public TMP_Text typeText;

    private Astre astreSelectionne;

    public float zoomDistance = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Astre astre = hit.collider.GetComponent<Astre>();
                if (astre != null)
                {
                    AfficherInfo(astre);
                }
            }
        }
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
