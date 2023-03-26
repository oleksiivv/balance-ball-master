using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    public Material[] skins;
    private MeshRenderer mesh;

    void Start(){
        mesh=gameObject.GetComponent<MeshRenderer>();

        mesh.material=skins[PlayerPrefs.GetInt("CurrentPlayerMaterial")];
    }


}
