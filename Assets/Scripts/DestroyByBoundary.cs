using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit(Collider other)
	{
        if (other.tag != "Boss")
        {
            Destroy(other.gameObject);
        }
		if (other.tag != "Boss" && other.tag != "BossBoundary") 
		{
			Destroy (other.gameObject);
		}
	}
}
