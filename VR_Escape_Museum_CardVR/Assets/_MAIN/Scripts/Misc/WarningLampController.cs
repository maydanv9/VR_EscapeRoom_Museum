using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningLampController : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshRenderer xd;
    void Start()
    {
        StartCoroutine(XD());
    }
    
    private IEnumerator XD()
    {
        while (true)
        {
            xd.sharedMaterial.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(1);
            xd.sharedMaterial.DisableKeyword("_EMISSION");
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }
}
