using System;
using System.Collections.Generic;
using System.Text;
using StorageModel;

namespace Project_Storage
{
    public class Mock
    {
        public static Dictionary<long, string> Catalog = new Dictionary<long, string>
        {
            [1928365746539] = "Миска для животных  Welovepet",
            [6473846538247] = "Миска для животных FOXIE",
            [5973754739471] = "Когтеточка настенная угловая Take Easy",
            [6372846463512] = "Когтеточка для кошек BigHouse",
            [9082836562820] = "Домик для животных Bigarden",
            [3275694862906] = "Домик - люлька для кошек FISSA",
            [4572947586352] = "Носки для кошек и собак нескользящие GABYDOG",
            [2998679038591] = "Толстовка Superman для собак и кошек",
        };

        public static Dictionary<string, long> Locations = new Dictionary<string, long>
        {
            ["AB.000-a0"] = 1928365746539,
            ["BA.001-b1"] = 6473846538247,
            ["C.012-c2"] = 5973754739471,
            ["D.013-d3"] = 6372846463512,
            ["E.024-e4"] = 9082836562820,
            ["F.035-f5"] = 3275694862906,
            ["G.046-a6"] = 4572947586352,
            ["H.047-b7"] = 2998679038591,
            ["I.148-c8"] = 9082836562820,
            ["J.149-d9"] = 1928365746539,
            ["K.250-e0"] = 9082836562820,
            ["L.251-f1"] = 4572947586352,
            ["M.321-g7"] = 0,
        };

        public static Dictionary<string, int> CountProduct = new Dictionary<string, int>
        {
            ["AB.000-a0"] = 19,
            ["BA.001-b1"] = 67,
            ["C.012-c2"] = 471,
            ["D.013-d3"] = 612,
            ["E.024-e4"] = 20,
            ["F.035-f5"] = 36,
            ["G.046-a6"] = 42,
            ["H.047-b7"] = 21,
            ["I.148-c8"] = 90,
            ["J.149-d9"] = 20,
            ["K.250-e0"] = 90,
            ["L.251-f1"] = 452,
            ["M.321-g7"] = 0,
        };

        public static Dictionary<string, int> AllCount = new Dictionary<string, int> { };
    }
}
