using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStackManager : MonoBehaviour
{

    public PlayerManager playerManager;

    public Transform firstStackPos;
    public float scaleDownRate = 1.2f;
    private List<GameObject> WoodList = new List<GameObject>();
    private Field field;
    
    private float buildingActionDelay = .1f;
    private float nextActionTime;
    
    
    // Start is called before the first frame update
    void Start()
    {
        field = FindObjectOfType<Field>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerManager.isPlayerBuilding)
        {
            BuildField();
        }
    }

  
    public void StackWood(Collider newObj)
    {
        Transform otherTransform = newObj.transform;
        Rigidbody otherRB = otherTransform.GetComponent<Rigidbody>();
        otherRB.isKinematic = true;
        newObj.enabled = false;
        
        otherTransform.position = new Vector3(firstStackPos.position.x,firstStackPos.position.y + ((newObj.transform.localScale.y / scaleDownRate) * WoodList.Count),
            firstStackPos.position.z);
        otherTransform.parent = firstStackPos;
        otherTransform.localRotation = Quaternion.Euler(Vector3.zero);
            
        otherTransform.localScale = otherTransform.localScale / scaleDownRate;
            
        WoodList.Add(newObj.gameObject);
        
    }

    public void BuildField()
    {
        if (Time.time > nextActionTime && !WoodList.Count.Equals(0) && !field.isBuildingDone)
        {
            nextActionTime = Time.time + (buildingActionDelay);
            RemoveWoodFromPlayer();
            AddWoodToField();
        }
    }
    
    public void RemoveWoodFromPlayer()
    {
        Destroy(WoodList[WoodList.Count-1]);
        WoodList.RemoveAt(WoodList.Count-1);
    }

    public void AddWoodToField()
    {
        field.AddWood();
    }
}
