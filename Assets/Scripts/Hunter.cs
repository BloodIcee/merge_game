using UnityEngine;

public class Hunter : AnimalEntity
{
    private Rigidbody rb;

    public override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Prey>())
        {
            DealDamage();
            transform.localPosition = Vector3.zero;

            HuntManager.instance.ChooseAnotherAnimal();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<DeathZone>())
        {
            transform.parent = HuntManager.instance.animalPool.transform;
            transform.localPosition = Vector3.zero;
            rb.isKinematic = true;
            rb.useGravity = false;

            gameObject.SetActive(false);

            HuntManager.instance.ChooseAnotherAnimal();
        }
    }

    private void DealDamage()
    {
        HuntManager.instance.UpdateProgress(animalConfig.GetAnimalDamage);
    }
}
