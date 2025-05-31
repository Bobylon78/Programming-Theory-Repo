using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public Camera mainCamera;
    public Transform currentTarget;
    public Transform pivotPoint;
    public float zoomDistance = 1f;
    public float zoomSpeed = 1f;
    public float rotationSpeed = 50f;
    public Vector3 offsetDirection = new Vector3(1f, 0.5f, -1f);
    private Vector3 targetPosition;
    public bool isZooming = false;
    public Transform initPositionPoint;
    public GameObject buttonRetour;

    public GameObject panelInfo;
    public TMP_Text nomText;
    public TMP_Text masseText;
    public TMP_Text rayonText;
    public TMP_Text colorText;
    public TMP_Text vitesseOrbitalText;
    public TMP_Text vitesseRotationText;
    public TMP_Text typeText;
    public TMP_Dropdown dropdownAstres;
    public List<Astre> tousLesAstres;

    private Astre astreSelectionne;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<string> noms = new List<string>();
        foreach (Astre astre in tousLesAstres)
        {
            noms.Add(astre.Nom);
        }
        dropdownAstres.ClearOptions();
        dropdownAstres.AddOptions(noms);
        dropdownAstres.onValueChanged.AddListener(SelectionDropdownAstre);


    }
    // Update is called once per frame
    void Update()
    {

        RotationCamera();
        if (isZooming)
        {
            mainCamera.transform.position = Vector3.Lerp(targetPosition, targetPosition, zoomSpeed * Time.deltaTime);
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
        if (buttonRetour != null)
        {
            buttonRetour.SetActive(isZooming);
        }
    }
    void RotationCamera()
    {
        pivotPoint.position = currentTarget.position;
        float horizontalInput = 0f;
        if (Input.GetKey(KeyCode.A))

            horizontalInput = -1f;

        else if (Input.GetKey(KeyCode.D))
            horizontalInput = 1f;
        if (horizontalInput != 0f)
        {
            pivotPoint.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
            Debug.Log("ALEZRTE");
        }

    }
    public void ZoomToAstre(Transform astre)
    {
        currentTarget = astre;
        pivotPoint.position = currentTarget.position;
        pivotPoint.transform.SetParent(astre);
        mainCamera.transform.SetParent(null);
        Vector3 offset = offsetDirection.normalized * zoomDistance;
        targetPosition = astre.position + offset;
        mainCamera.transform.localPosition = offset;
        mainCamera.transform.LookAt(pivotPoint.position);
        isZooming = true;
    }
    public void SelectionDropdownAstre(int index)
    {
        if (index >= 0 && index < tousLesAstres.Count)
        {
            Astre astre = tousLesAstres[index];
            ZoomToAstre(astre.transform);
            AfficherInfo(astre);
        }
    }



    public void AfficherInfo(Astre astre)
    {
        astreSelectionne = astre;
        panelInfo.SetActive(true);
        nomText.text = astre.Nom;
        masseText.text = "Masse : " + astre.Masse + "kg";
        rayonText.text = "Equateur : " + (astre.Diametre + "km");
        colorText.text = "Couleur : " + astre.Couleur;
        vitesseOrbitalText.text = "Révolution Orbital : " + astre.VitesseOrbitalReel;
        vitesseRotationText.text = "Rotation : " + astre.VitesseRotationReel;
        typeText.text = "Type : " + astre.Type;
    }

    public void RetourZoom()
    {
        if (initPositionPoint != null)
        {
            mainCamera.transform.SetParent(null);
            mainCamera.transform.position = initPositionPoint.position;
            mainCamera.transform.rotation = initPositionPoint.rotation;
            pivotPoint.transform.SetParent(GameObject.Find("Vénus").transform);
            mainCamera.transform.SetParent(pivotPoint);
            isZooming = false;
            currentTarget = GameObject.Find("Vénus").transform;
            buttonRetour.SetActive(false);
            panelInfo.SetActive(false);
        }
    }

}