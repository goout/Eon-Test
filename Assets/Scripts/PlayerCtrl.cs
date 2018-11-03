using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

    Animator anim;

    [SerializeField] private CharacterController characterController;

    private Vector3 mousePos;
    private Vector3 screenPos;

    private float distanceFromObject;

    private bool strongAttack = false;


    [SerializeField] private LayerMask layerMask;

    private Vector3 currentLookTarget = Vector3.zero;



    void Awake() {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update() {
        MoveVertical();
        MoveHorizontal();

        if (Input.GetButtonDown("Fire1")) {
			anim.ResetTrigger("StrongAttack");
            anim.SetTrigger("Attack");
        }

        if (Input.GetButtonDown("Fire2")) {
            anim.SetTrigger("StrongAttack");
        }

    }


    void FixedUpdate() {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 500, Color.blue);

        if (Physics.Raycast(ray, out hit, 500, layerMask, QueryTriggerInteraction.Ignore)) {
            if (hit.point != currentLookTarget) {
                currentLookTarget = hit.point;
            }

            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10f);

        }

    }

    void MoveVertical() {
        anim.SetFloat("Vertical", Input.GetAxis("Vertical"));
    }

    void MoveHorizontal() {
        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
    }

}
