using UnityEngine;
using UnityEditor;

public class Visualizador : MonoBehaviour
{
    public Arbol arbol = new();
    public Vector3 origin = Vector3.zero;
    public float xSpacing = 2f, ySpacing = 2f;

    private void OnDrawGizmos()
    {
        if (arbol == null || arbol.Root == null) return;
        Gizmos.color = Color.white;
        DrawNode(arbol.Root, origin, xSpacing);
    }

    private void DrawNode(Nodo node, Vector3 position, float xOffset)
    {
        if (node == null) return;
        Gizmos.DrawSphere(position, 0.2f);

        Handles.Label(position + Vector3.up * 0.3f, node.Value.ToString());

        if (node.Left != null)
        {
            Vector3 leftPos = position + new Vector3(-xOffset, -ySpacing, 0);
            Gizmos.DrawLine(position, leftPos);
            DrawNode(node.Left, leftPos, xOffset / 2);
        }

        if (node.Right != null)
        {
            Vector3 rightPos = position + new Vector3(xOffset, -ySpacing, 0);
            Gizmos.DrawLine(position, rightPos);
            DrawNode(node.Right, rightPos, xOffset / 2);
        }
    }
}