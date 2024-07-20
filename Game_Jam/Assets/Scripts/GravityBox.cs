using System.Collections;
using UnityEngine;

public class GravityBox : MonoBehaviour
{

    [SerializeField] BoxType boxType;
    Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale =0;
        rb.isKinematic = true;
    }
    bool used;
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(used) return;


        if(other.gameObject.TryGetComponent<IGravityBoxClient>(out IGravityBoxClient component))
        {
            used = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        
        if(!used) return;

        if(other.gameObject.TryGetComponent<IGravityBoxClient>(out IGravityBoxClient component))
        {
            if(used)
            {
                StartCoroutine(Delay());
            }
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);
        switch(boxType)
        {
            case BoxType.Fall :
                rb.isKinematic = false;
                rb.gravityScale = 1;
            break;

            case BoxType.Destroy :
                Destroy(gameObject);
            break;

        }

    }

    enum BoxType
    {
        Fall , 
        Destroy
    }
}
