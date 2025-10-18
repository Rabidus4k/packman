using UnityEngine;
using UnityEngine.Events;
using VInspector;

[DisallowMultipleComponent]
public class CollisionEventsHub : MonoBehaviour
{
    [Tab("Settings")]
    [Header("Filters")]
    [Tooltip("Какие слои пропускать. ~0 = все слои")]
    public LayerMask layerMask = ~0;

    [Tooltip("Писать подробный лог о столкновениях")]
    public bool logToConsole = false;

    [System.Serializable] public class CollisionEvent : UnityEvent<Collision> { }
    [System.Serializable] public class TriggerEvent : UnityEvent<Collider> { }

    [Tab("Events")]
    [Header("3D: Collision")]
    public CollisionEvent OnCollisionEnterEvent;
    public CollisionEvent OnCollisionStayEvent;
    public CollisionEvent OnCollisionExitEvent;

    [Header("3D: Trigger")]
    public TriggerEvent OnTriggerEnterEvent;
    public TriggerEvent OnTriggerStayEvent;
    public TriggerEvent OnTriggerExitEvent;

    // ===== Helpers =====
    private bool Pass3D(Collider col)
    {
        if (col == null) return false;

        if ((layerMask.value & (1 << col.gameObject.layer)) == 0) return false;

        return true;
    }

    private void Log(string evt, GameObject other, Vector3 point = default, Vector3 normal = default, float impulse = 0f)
    {
        if (!logToConsole) return;
        Debug.Log($"[{name}] {evt} with <{other.name}> @ {point} n={normal} impulse={impulse}", this);
    }

    private void OnCollisionEnter(Collision c)
    {
        if (!Pass3D(c.collider)) return;
        var cp = c.contactCount > 0 ? c.GetContact(0) : default;
        Log("OnCollisionEnter", c.collider.gameObject, cp.point, cp.normal, c.impulse.magnitude);
        OnCollisionEnterEvent?.Invoke(c);
    }

    private void OnCollisionStay(Collision c)
    {
        if (!Pass3D(c.collider)) return;
        OnCollisionStayEvent?.Invoke(c);
    }

    private void OnCollisionExit(Collision c)
    {
        if (!Pass3D(c.collider)) return;
        Log("OnCollisionExit", c.collider.gameObject);
        OnCollisionExitEvent?.Invoke(c);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Pass3D(other)) return;
        Log("OnTriggerEnter", other.gameObject);
        OnTriggerEnterEvent?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!Pass3D(other)) return;
        OnTriggerStayEvent?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!Pass3D(other)) return;
        Log("OnTriggerExit", other.gameObject);
        OnTriggerExitEvent?.Invoke(other);
    }
}
