using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Story2 : MonoBehaviour
{
    public GameObject thunders1;
    public GameObject thunders2;
    public GameObject thunders3;
    public GameObject fairyObject;
    public Animator fairy;
    public GameObject teddyObject;
    public Animator teddy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Thunder());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Thunder()
    {
        yield return new WaitForSeconds(1.5f);
        thunders1.SetActive(true);
        fairyObject.SetActive(true);
        fairy.SetTrigger("Dark Fairy Move");
        yield return new WaitForSeconds(1.5f);
        thunders1.SetActive(false);
        thunders2.SetActive(true);
        teddyObject.SetActive(true);
        teddy.SetTrigger("Teddy Move");
        yield return new WaitForSeconds(1.5f);
        thunders2.SetActive(false);
        thunders3.SetActive(true);
    }
}
