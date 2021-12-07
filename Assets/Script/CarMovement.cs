using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform attackPos;

    [SerializeField] Transform target;
    [SerializeField] Transform shootPos;

    [SerializeField] GameObject bullet;

    [SerializeField] float shootSpeed;
    [SerializeField] Transform machineGun;
    [SerializeField] float rotateSpeed;

    NavMeshAgent agent;

    bool attacked = false;// biến check xem machine gun đã bắn chưa


    private void Start()
    {
        //tìm vị trí của attack pos
        attackPos = GameObject.FindGameObjectWithTag("AttackPos").transform;

        agent = GetComponent<NavMeshAgent>();

        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        agent.SetDestination(attackPos.position);//đặt điểm đến cho agent

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "AttackPos") //nếu chạm vào game object có tag là AttackPos thì thực hiện xoay vào bắn
        {
            Debug.Log(attacked);

            if (RotateMachineGun() && !attacked)// nếu hàm RotateMachineGun trả về true, và biến chưa đánh trả true
            {
                attacked = true;
                StartCoroutine(Wait2Shoot());
            }

        }
    }

    private void Shoot()
    {
        GameObject bulletObject = Instantiate(bullet, shootPos.position, shootPos.rotation); //sinh viên đạnn

        Rigidbody bulletRB = bulletObject.GetComponent<Rigidbody>();// lấy rigidbody của viên đạn

        bulletRB.AddForce(bulletRB.transform.forward * shootSpeed, ForceMode.Impulse);// thực hiện bắn

        Destroy(bulletObject, 1f); //xóa bullet

    }

    private bool RotateMachineGun()
    {
        Vector3 targetDirection = target.position - machineGun.position; //hướng của target

        float speed = rotateSpeed * Time.deltaTime;// tính tốc độ xoay

        Vector3 newDirection = Vector3.RotateTowards(machineGun.forward, targetDirection, speed, 0f); //chỉ ra hướng của mục tiêu

        Debug.DrawRay(machineGun.position, newDirection, Color.red); //vẽ một đường ray cast chỉ đến mục tiêu

        //check true false, nếu chỉ đến turret thì trả về true ???

        machineGun.rotation = Quaternion.LookRotation(newDirection);//thực hiện quay

        return true;//trả về true nếu đã quay đến hướng turret
    }

    IEnumerator Wait2Shoot()
    {
        yield return new WaitForSeconds(4f);// đợi 1 s rồi bắn

        Shoot();

        yield return new WaitForSeconds(4f); //đợi 1 s rồi thực hiện tìm mục tiêu khác để di chuyển đến

        attacked = false;

        agent.SetDestination(attackPos.position);//đặt điểm đến cho agent

    }

}
