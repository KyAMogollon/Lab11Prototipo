using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> objectsPool;
    public GameObject objPref;
    private float currentTime;
    // Start is called before the first frame update
    public void GetObject(Vector3 origin)
    {
        GameObject tmp;
        if (objectsPool.Count > 0)
        {
            tmp = objectsPool[0];
            objectsPool.Remove(tmp);
            tmp.transform.position = origin + Vector3.right * 0.7f;
            tmp.SetActive(true);
        }
        else
        {
            tmp = Instantiate(objPref, origin + Vector3.right * 0.7f, objPref.transform.rotation);
            //tmp.GetComponent<BulletController>().SetDinamicPool(this);
            tmp.transform.SetParent(this.transform);
            tmp.SetActive(true);
        }
    }
    public void SetObject(GameObject obj, float frameRate)
    {
        obj.SetActive(false);
        objectsPool.Add(obj);
    }
}
