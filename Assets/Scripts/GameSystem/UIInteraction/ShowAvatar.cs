using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAvatar : MonoBehaviour
{
    public GameObject WindowToOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       StartCoroutine(IterateMenu());
    }

    private IEnumerator IterateMenu()
    {
        while (true)
        {
            WindowToOpen.SetActive(true);
            yield return new WaitForSeconds(10);
            WindowToOpen.SetActive(false);

        }
    }
}
