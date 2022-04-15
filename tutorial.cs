using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public List<Transform> page = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlayPage()
    {
        yield return new WaitForSeconds(0.5f);

        page[0].gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        page[0].gameObject.SetActive(false);
        page[1].gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        page[1].gameObject.SetActive(false);
        page[2].gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        page[2].gameObject.SetActive(false);
        page[3].gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        page[3].gameObject.SetActive(false);
        page[4].gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        page[4].gameObject.SetActive(false);
        page[5].gameObject.SetActive(true);
   
        yield return new WaitForSeconds(5f);
        page[5].gameObject.SetActive(false);
    }


}
