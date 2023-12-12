using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6TW4A_HFT_2023241.Logic.LogicModels
{
    public class RankComparer : IComparer<string>
    {
        public int Compare(string a, string b)
        {
            if (a.IsNullOrEmpty() || b.IsNullOrEmpty())
            {
                throw new ArgumentException("Rank is null");
            }
            else
            {
                string rank = a[0].ToString();
                rank += b[0].ToString();
                if (rank[0].Equals(rank[1]))
                {

                    int[] tier = new int[2];
                    tier[0] = int.Parse(a[1].ToString());
                    tier[1] = int.Parse(b[1].ToString());
                    if (tier[0] == tier[1])
                    {
                        return 1;
                    }
                    else if (tier[0] > tier[1])
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    var c = rank.OrderBy(x => x);
                    if (rank[0].Equals(c.First()) && !rank[1].Equals("S"))
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }
    }
}
