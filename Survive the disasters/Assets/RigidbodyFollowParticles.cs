using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(Rigidbody))]
public class RigidbodyFollowParticles : MonoBehaviour
{
    ParticleSystem m_particlesSystem;
    ParticleSystem.Particle[] m_particles;
    Rigidbody m_rigidbody;
    public static int numOfParticleRigidbodies = 0;
    private bool alreadyActive = false;

    public bool affectedByWind = true;
    void Start()
    {
        m_particlesSystem = gameObject.GetComponent<ParticleSystem>();
        m_particles = new ParticleSystem.Particle[1];
        m_rigidbody = gameObject.GetComponent<Rigidbody>();

        //Setup Particle System
        ParticleSystemRenderer psRend = m_particlesSystem.GetComponent<ParticleSystemRenderer>();
        psRend.enabled = false;
        ParticleSystem.MainModule psMain = m_particlesSystem.main;
        psMain.startLifetimeMultiplier = Mathf.Infinity;
        psMain.startSpeed = 0; // only wind affects velocity
        psMain.simulationSpace = ParticleSystemSimulationSpace.World;
        psMain.maxParticles = 1;
        //can't set the following with code manual change is necessary
        //1 - Enable "External Forces"
        //3 - (pretty much worthless) Set Emmision Rate Over Time to 1
    }

    private void FixedUpdate()
    {
        if (affectedByWind)
        {
            m_particlesSystem.GetParticles(m_particles); //Update particle array so new particles can be detected
            m_rigidbody.AddForce(50 * m_particles[0].velocity);
          //m_rigidbody.velocity += m_particles[0].velocity;
            m_particles[0].position = m_rigidbody.position;
            m_particles[0].velocity = Vector3.zero;
            m_particlesSystem.SetParticles(m_particles, 1);  ////Assign particle array to particle system to prevent bugs
        }
    }

    public void StartWindSimulation()
    {
        //the below is to start the particle at the center
        affectedByWind = true;
        m_particlesSystem.Emit(1); //emit 1 particle
        m_particlesSystem.GetParticles(m_particles); //write displayed particles to particles array
        m_particlesSystem.SetParticles(m_particles, 1); //Assign particle array to particle system
        numOfParticleRigidbodies++;

    }

    public void StopParticleSystem()
    {
        affectedByWind = false;
        m_particlesSystem.SetParticles(m_particles, 0);
        numOfParticleRigidbodies--;
    }
}
