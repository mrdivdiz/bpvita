using UnityEngine;

public class WaveMover : MonoBehaviour
{
    private void Start()
    {
        this.m_origPos = base.transform.position;
        this.m_origScale = base.transform.localScale;
        this.cachedTransform = base.transform;
        this.m_periodX = this.m_startX;
        this.m_periodY = this.m_startY;
        this.m_periodScale = this.m_startScale;
        this.m_lastRT = Time.realtimeSinceStartup;
    }

    private void Update()
    {
        float realtimeSinceStartup = Time.realtimeSinceStartup;
        float num = Time.deltaTime;
        if (this.m_useRealtime)
        {
            num = realtimeSinceStartup - this.m_lastRT;
            if (num <= 0f || num > 0.2f)
            {
                num = 0.05f;
            }
        }
        this.m_lastRT = realtimeSinceStartup;
        float num2 = num * this.m_speedX;
        this.m_periodX += num2;
        if (this.m_periodX > 3.14159274f)
        {
            this.m_periodX -= 6.28318548f;
        }
        this.m_periodY += num * this.m_speedY;
        if (this.m_periodY > 3.14159274f)
        {
            this.m_periodY -= 6.28318548f;
        }
        Vector3 position = this.m_origPos + this.cachedTransform.up * Mathf.Sin(this.m_periodX) * this.m_rangeX + this.cachedTransform.right * Mathf.Sin(this.m_periodY) * this.m_rangeY;
        float b = (float)((this.cachedTransform.position.y - position.y > 0f) ? 50 : 0);
        this.cachedTransform.position = position;
        for (int i = 0; i < this.cachedTransform.childCount; i++)
        {
            Transform transform = this.cachedTransform.GetChild(i);
            float x = transform.eulerAngles.x;
            transform.eulerAngles = new Vector3(Mathf.Lerp(x, b, num2), 0f, 0f);
        }
        this.m_periodScale += num * this.m_speedScale;
        if (this.m_periodScale > 3.14159274f)
        {
            this.m_periodScale -= 6.28318548f;
        }
        Vector3 localScale = this.m_origScale + Mathf.Sin(this.m_periodScale) * this.m_rangeScale * this.m_origScale;
        this.cachedTransform.localScale = localScale;
    }

    public bool m_useRealtime;

    public float m_rangeX;

    public float m_speedX;

    public float m_rangeY;

    public float m_speedY;

    public float m_startX;

    public float m_startY;

    public float m_rangeScale = 1.5f;

    public float m_speedScale;

    public float m_startScale = 1f;

    protected Vector3 m_origPos;

    protected Vector3 m_origScale;

    protected float m_periodX;

    protected float m_periodY;

    protected float m_periodScale;

    protected float m_lastRT;

    private Transform cachedTransform;
}
