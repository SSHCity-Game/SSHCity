using System.Collections.Generic;
using Godot;

namespace SshCity.Scenes.Plan
{
    public class Delete
    {
        public static void DeleteNode(PlanInitial planInitial, Vector2 pos)
        {
            bool delete = false;
            int length = MainPlan.ListeNode.Count;
            int numberNodeSupp = 0;
            List<(Vector2, int)> res = new List<(Vector2, int)>();
            for (int j = 0; j < length; j++)
            {
                (Vector2 posNode, int number_node)= MainPlan.ListeNode[j];
                if (delete)
                {
                    res.Add((posNode, number_node-1));
                }
                else if (posNode == pos && !delete)
                {
                    GD.Print(planInitial.GetChild(number_node).Name);
                    planInitial.GetChild(number_node).QueueFree();
                    delete = true;
                }
                else
                {
                    res.Add((posNode, number_node));
                }

            }
            MainPlan.ListeNode = res;


            for (int i = 0; i < length-1; i++)
            {
                GD.Print(MainPlan.ListeNode[i]);
            }
        }
    }
}