using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedInformationController : MonoBehaviour
{
    public static SelectedInformationController instance;

    private Image selectedImage;
    private Text selectedName;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        selectedImage = transform.GetChild(0).gameObject.GetComponent<Image>();
        selectedName = transform.GetChild(1).gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshSelected(string path){
        GameObject prefab = Resources.Load<GameObject>(path);

        selectedImage.sprite = prefab.GetComponentInChildren<SpriteRenderer>().sprite;
        selectedName.text = prefab.GetComponent<GardenItem>().itemName;
    }


}
