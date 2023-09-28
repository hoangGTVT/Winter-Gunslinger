using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObject : MonoBehaviour
{
    protected virtual PlayerLife FindObjectsToGetComponent(string name, PlayerLife playerLife)
    {
       
        GameObject nn=GameObject.FindGameObjectWithTag(name);
        if(nn != null)
        {
            playerLife = nn.GetComponent<PlayerLife>();


           
        }
        return playerLife;



    }
    protected virtual GameObject FindObjectWithTag(string name)
    {
       return GameObject.FindGameObjectWithTag(name);
    }

    protected virtual Component FindComponentOnObjectWithTag(string tag, string componentName)
    {
        GameObject foundObject = GameObject.FindGameObjectWithTag(tag);

        if (foundObject != null)
        {
            Component[] components = foundObject.GetComponents<Component>();

            // Duyệt qua tất cả các thành phần trên đối tượng
            foreach (Component component in components)
            {
                if (component.GetType().Name == componentName)
                {
                    // Tìm thấy thành phần cần tìm
                    return component;
                }
            }

            
        }
       

        // Trả về null nếu không tìm thấy đối tượng hoặc thành phần
        return null;
    }
}
