using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UITweenTest : MonoBehaviour
{
    public Transform nom;


    // Start is called before the first frame update
    void Start()
    {
        //nom.transform.DOMoveX(nom.transform.position.x + 500f, 5f);
        //nom.transform.DOMove(nom.transform.position + (Vector3.right * 500), 5f);
        //nom.transform.DORotate(nom.transform.rotation.eulerAngles + new Vector3(0f, 0f, -180f), 5f);

        //A sequence is a sequence of tweens that will be done in order, based on appending them or inserting them at a certain time
        Sequence s = DOTween.Sequence();
        //We start off this sequence with an append so it's the first thing that happens. We take the original position and
        //move it to the right.
        s.Append(nom.transform.DOMove(nom.transform.position + (Vector3.right * 500), 5f));
        //We need to insert the rotation so that it happens at the same time as the first appended movement in the sequence.
        //By giving it a start time of 0f , we start it immediately when the sequence starts so it happns at the same time.
        s.Insert(0f, nom.transform.DORotate(nom.transform.rotation.eulerAngles + new Vector3(0f, 0f, -180f), 5f));
        //We append the next part of the sequence what will happen once the previous Append ends. In this case, we move it to the
        //original position, since when we build the sequence, its using the same value before it was moved. If we subtracted from it 
        //now, it would take the original position and move it -500 instead of going back to the original position
        s.Append(nom.transform.DOMove(nom.transform.position, 5f));
        s.Insert(5f, nom.transform.DORotate(nom.transform.rotation.eulerAngles, 5f));
        s.PlayForward();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Kill all will stop all the tweens in their current position
            //DoTween.KillAll();

            //CompleteAll will take all current tweens and set them to their end position, including all the onces in a sequence
            DOTween.CompleteAll();

            //If we complete or kill a singular one, we need to pass in the object that has a tween on it. In this case
            DOTween.Complete(nom.transform);
            
            
        }
    }
}
