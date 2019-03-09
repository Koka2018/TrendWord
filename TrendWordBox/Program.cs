using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendWordGear;

namespace TrendWordBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctrl = new TrendWordCtrl();

            var tbl = ctrl.GetTokenTbl("「ガンダム」とはアニメ作品『機動戦士ガンダム』劇中に登場したモビルスーツ（ロボット）・「ガンダム」のことだが、「ガンプラ」という名称を広義に用いる場合は単にガンダム一体だけを指すのではなく、「ガンダムシリーズ」全体に登場する他のモビルスーツやモビルアーマー等と呼ばれる兵器、および艦船など、商品としてプラモデル化されているもの全ての総称として用いられる。 ");
            Console.ReadLine();
        }
    }
}
