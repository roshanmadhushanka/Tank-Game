using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANKiClient.Model
{
    class Tank : GameObject
    {
        public int direction { set; get; }
        public bool shot { set; get; }
        public int coin { set; get; }
        public int points { set; get; }

    }
}
