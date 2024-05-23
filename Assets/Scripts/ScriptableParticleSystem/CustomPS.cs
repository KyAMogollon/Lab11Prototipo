using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableParticleSystem
{
    public class CustomPS : MonoBehaviour
    {
        [SerializeField] private Particle SystemParticle;

        //[SerializeField] private int numberParticles;
        [SerializeField] private MovingParticle prefabParticle;

        [SerializeField] CustomDirection AxisX;
        [SerializeField] CustomDirection AxisY;
        [SerializeField] CustomDirection AxisZ;

        [SerializeField] CustomVelocity Velocity;

        [SerializeField] CustomDeathLife life;

        private MovingParticle[] particles;


        
        IEnumerator SpawnOneParticle()
        {
            InstanteParticle();
            Debug.Log("Te llame");
            yield return new WaitForSecondsRealtime(1.0f);
            StartCoroutine(SpawnOneParticle());
        }

        private void InstanteParticle()
        {
            MovingParticle particles = Instantiate(prefabParticle);
            particles.GetComponent<MovingParticle>().DestroyObject(life.RandomLife());
            particles.SetUp(SystemParticle, transform.position, new Vector3(AxisX.RandomPositions(), AxisY.RandomPositions(), AxisZ.RandomPositions()), 1f);
            particles.GetComponent<MovingParticle>().SetVelocity(Velocity.RandomVelocity());
            
        }

        private void Start()
        {
            //particles = new MovingParticle[numberParticles];

            //for (int i = 0; i < numberParticles; i++)
            //{
            //    particles[i] = Instantiate(prefabParticle);
            //    particles[i].SetUp(SystemParticle, transform.position, new Vector3(AxisX.RandomPositions(),AxisY.RandomPositions(),AxisZ.RandomPositions()), 1f);
            //}

            StartCoroutine(SpawnOneParticle());
        }
        private void Update()
        {
            //for (int i = 0; i < numberParticles; i++)
            //{
            //    particles[i].Move(SystemParticle.curve.Evaluate(Time.time * 0.01f));
            //}
        }
    }
    [System.Serializable]
    public struct CustomDirection
    {
        public float minV;
        public float maxV;

        public float RandomPositions()
        {
            return Random.Range(minV, maxV);
        }
    }

    [System.Serializable]
    public struct CustomVelocity
    {
        public float minV;
        public float maxV;

        public float RandomVelocity()
        {
            return Random.Range(minV, maxV);
        }
       
    }
    [System.Serializable]
    public struct CustomDeathLife
    {
        public float minV;
        public float maxV;

        public float RandomLife()
        {
            return Random.Range(minV, maxV);
        }
       
    }
}
