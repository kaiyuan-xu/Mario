
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANode
{
    public Vector2 Position;
    public int Row, Colume;
    public ANode Parent;
    public bool IsObstacle;

    //到目的地
    public int HCost;
    //到起点
    public int GCost;
    //总消耗
    public int FCost { get { return HCost + GCost; } }

    public ANode(bool isObstacle, Vector2 pos, int row, int colume)
    {
        IsObstacle = isObstacle;
        Position = pos;
        Row = row;
        Colume = colume;
    }
}

public class AFindPath : MonoBehaviour
{
    public float Radius = 0.5f;
    public LayerMask ColliderLayer;

    private ANode[,] nodes;
    private int Colume, Row;
    private float lbx, lby;
    private float width, height;

    void Awake()
    {
        Init();

    }

    void Init()
    {

        width = transform.localScale.x * GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        height = transform.localScale.y * GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        lbx = transform.position.x - Mathf.Abs(transform.localScale.x * GetComponent<SpriteRenderer>().sprite.bounds.min.x);
        lby = transform.position.y - Mathf.Abs(transform.localScale.x * GetComponent<SpriteRenderer>().sprite.bounds.min.y);
        Colume = Mathf.RoundToInt(width / (Radius * 2));
        Row = Mathf.RoundToInt(height / (Radius * 2));
        nodes = new ANode[Row, Colume];
        Debug.Log(nodes.Length);
        for (int i = 0; i < Row; i++)
        {
            for (int j = 0; j < Colume; j++)
            {
                Vector2 pos = new Vector2(lbx + j * Radius * 2 + Radius, lby + Radius * 2 * i + Radius);
                Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, Radius, ColliderLayer);
                bool isObstacle = colliders.Length > 0 ? true : false;
                nodes[i, j] = new ANode(isObstacle, pos, i, j);
            }
        }
    }

    private ANode GetNodeByPosition(Vector2 pos)
    {
        int colume = (int)(Mathf.Clamp01(Mathf.Abs(pos.x - lbx) / width) * (Colume));
        int row = (int)(Mathf.Clamp01(Mathf.Abs(pos.y - lby) / height) * (Row));

        return nodes[row, colume];
    }


    private List<ANode> GetNearNodes(ANode node)
    {
        List<ANode> list = new List<ANode>();
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if (i == 0 && j == 0) continue;
                int row = node.Row + i;
                int colume = node.Colume + j;
                if (row >= 0 && row < Row && colume >= 0 && colume < Colume)
                {
                    list.Add(nodes[row, colume]);
                }
            }
        }
        return list;
    }

    int getCost(ANode a, ANode b)
    {
        int cntX = Mathf.Abs(a.Colume - b.Colume);
        int cntY = Mathf.Abs(a.Row - b.Row);
        if (cntX > cntY)
        {
            return 14 * cntY + 10 * (cntX - cntY);
        }
        else
        {
            return 14 * cntX + 10 * (cntY - cntX);
        }
    }


    /// <summary>
    /// 寻找路径
    /// </summary>
    /// <param name="start">起点坐标</param>
    /// <param name="end">结束点坐标</param>
    public Vector2[] FindingPath(Vector2 start, Vector2 end)
    {
        ANode startNode = GetNodeByPosition(start);
        ANode endNode = GetNodeByPosition(end);
        List<ANode> openList = new List<ANode>();
        List<ANode> closeList = new List<ANode>();
        openList.Add(startNode);
        while (openList.Count > 0)
        {
            ANode currentNode = openList[0];
            for (int i = 0; i < openList.Count; i++)
            {
                if (openList[i].FCost < currentNode.FCost ||
                    openList[i].FCost == currentNode.FCost &&
                    openList[i].HCost < currentNode.HCost)
                {
                    currentNode = openList[i];
                }
            }

            openList.Remove(currentNode);
            closeList.Add(currentNode);

            if (currentNode == endNode)
            {
                List<ANode> path = new List<ANode>();
                ANode temp = endNode;
                while (temp != startNode)
                {
                    path.Add(temp);
                    temp = temp.Parent;
                }
                List<Vector2> pos = new List<Vector2>();
                for (int i = path.Count - 1; i >= 0; i--)
                {
                    pos.Add(path[i].Position);
                }
                return pos.ToArray();
            }
            foreach (ANode node in GetNearNodes(currentNode))
            {
                if (node.IsObstacle == true || closeList.Contains(node))
                {
                    continue;
                }

                int GCost = currentNode.GCost + getCost(currentNode, node);
                if (GCost < node.GCost || !openList.Contains(node))
                {
                    node.GCost = GCost;
                    node.HCost = getCost(node, endNode);
                    node.Parent = currentNode;
                    if (openList.Contains(node) == false)
                    {
                        openList.Add(node);
                    }
                }
            }
        }
        return new List<Vector2>().ToArray();
    }
}

