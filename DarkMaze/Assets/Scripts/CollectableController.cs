using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour, IInteractable
{
    public float speed = 1f;
    public Vector3 rotationAngles = new Vector3(15, 30, 45);

    private static bool fequals(float x, float y, float sigma = 1e-6f)
    {
        return Mathf.Abs(x - y) <= sigma;
    }

    private void Start()
    {
        if (fequals(speed, 0))
        {
            speed = Random.Range(.5f, 3f);
        }

        if (
            fequals(rotationAngles.x, 0)
            && fequals(rotationAngles.y, 0)
            && fequals(rotationAngles.z, 0)
        )
        {
            rotationAngles = new Vector3(
                Random.Range(15, 45),
                Random.Range(15, 45),
                Random.Range(15, 45)
            );
        }
    }

    void Update()
    {
        transform.Rotate(rotationAngles * speed * Time.deltaTime);
    }

    public void OnCollected()
    {
        StartCoroutine(PlayAndDie());
    }

    IEnumerator PlayAndDie()
    {
        GetComponent<MeshRenderer>().enabled = false;
        var source = GetComponent<AudioSource>();
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
        gameObject.SetActive(false);
    }
}
