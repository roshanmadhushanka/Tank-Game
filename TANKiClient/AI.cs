using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TANKiClient.Model;


namespace TANKiClient
{
    class AI
    {
        public const int UP = 0, RIGHT = 1, DOWN = 2, LEFT = 3;
        public static GameClient gameClient;
        const int TREASURE = 1;
        const int ENEMY = 2;
        const int CRITICAL_LIFE = 50;   //critical life level (for searching life packs)

        static Node myself, start, current, temp;
        static Tank myTank;
        static int myDirection;

        static List<Node> shortClose = new List<Node>(); //Shortest path for coin pile / health
        static List<Node> closed = new List<Node>();
        static List<Node> open = new List<Node>();

        public static bool ai_status { set; get; }
        
        //controller method; synchronized
        //[MethodImpl(MethodImplOptions.Synchronized)]
        public static void run()
        {
            Console.WriteLine("Nightmare started");
            //Check Tank is available or not
            findMe();
            if (myself == null)
            {
                //If not return
                return;
            }

            fire();                                                       
            findClosestCoinPile();    //Select closest coin pile
            if (shortClose.Count > 1)
            {
                //success! go get it
                move();
                Thread.Sleep(100);
            }
            else
            {
                //try to get a life pack
                findClosestLifePack();
                if (shortClose.Count > 1)
                {
                    //success! go get it
                    move();
                    Thread.Sleep(100);
                }

                //if path not found to life pack
                if (shortClose.Count == 0)
                {
                    //fire closest enemy
                    fire();
                }
            }
        }

        //find and return my tank in Node form (for AI)
        static public void findMe()
        {
            GameObject item;
            myself = null;
            myTank = null;

            for (int y = 0; y < Arena.size; y++)
            {
                for (int x = 0; x < Arena.size; x++)
                {
                    item = Arena.GetGameObject(x, y);
                    if (item is Tank && ((Tank)item).name == Tank.current_player_name)   
                    {
                        //Get Current Tank
                        myTank = (Tank)item;
                        myself = new Node();
                        myself.x = x;
                        myself.y = y;
                        myDirection = ((Tank)item).direction;
                        return;
                    }
                }
            }
        }

        //find shortest path to nearest coin pile
        public static void findClosestCoinPile()
        {
            GameObject item, tempItem;
            int pos, x, y;
            int tempMotion, motion = -1;

            //clean history before start
            shortClose.Clear();

            for (y = 0; y < Arena.size; y++)
            {
                for (x = 0; x < Arena.size; x++)
                {
                    item = Arena.GetGameObject(x, y);

                    if (item is Coin)
                    {
                        start = new Node();
                        start.f = 0;
                        start.g = 0;
                        start.h = 0;
                        start.x = x;
                        start.y = y;
                        start.motion = -1;
                        open.Add(start);

                        while (true)
                        {
                            //remove first element from open list and add it to close list
                            current = open[0];
                            closed.Add(current);
                            open.RemoveAt(0);

                            motion = current.motion;
                            tempMotion = -1;

                            for (int xT = current.x - 1; xT < current.x + 2; xT++)
                            {
                                if (xT < 0 || xT >= Arena.size) //out of bounds
                                    continue;

                                for (int yT = current.y - 1; yT < current.y + 2; yT++)
                                {
                                    //ignore current cell and diagonals
                                    if (!(xT == current.x ^ yT == current.y))
                                        continue;

                                    if (yT < 0 || yT >= Arena.size) //out of bounds
                                        continue;

                                    tempItem = Arena.GetGameObject(xT, yT);
                                    if (tempItem is StoneWall || tempItem is BrickWall || tempItem is Water ||
                                        (tempItem is Tank && ((Tank)tempItem).name != Tank.current_player_name))
                                        //obstacle or another tank! ignore
                                        continue;

                                    temp = new Node();
                                    temp.x = xT;
                                    temp.y = yT;
                                    temp.g = current.g + Math.Abs(xT - current.x) + Math.Abs(yT - current.y);

                                    //determine motion direction
                                    //add extra cost if direction must be changed
                                    if (xT > current.x)
                                    {
                                        if (motion != -1 && motion != RIGHT)
                                            temp.g++;
                                        tempMotion = RIGHT;
                                    }
                                    if (xT < current.x)
                                    {
                                        if (motion != -1 && motion != LEFT)
                                            temp.g++;
                                        tempMotion = LEFT;
                                    }
                                    if (yT > current.y)
                                    {
                                        if (motion != -1 && motion != DOWN)
                                            temp.g++;
                                        tempMotion = DOWN;
                                    }
                                    if (yT < current.y)
                                    {
                                        if (motion != -1 && motion != UP)
                                            temp.g++;
                                        tempMotion = UP;
                                    }

                                    temp.h = Math.Abs(xT - myself.x) + Math.Abs(yT - myself.y);
                                    temp.f = temp.g + temp.h;

                                    pos = open.IndexOf(temp);
                                    if (pos >= 0 && open[pos].g > temp.g)
                                    {
                                        open[pos].g = temp.g;
                                        open[pos].f = open[pos].g + open[pos].h;
                                    }
                                    else if (closed.IndexOf(temp) < 0)
                                    {
                                        temp.motion = tempMotion;
                                        open.Add(temp);
                                    }
                                }
                            }

                            //quit if nothing found
                            if (open.Count == 0)
                                break;

                            //sort open list
                            open.Sort(CompareNodes);

                            //exit condition
                            if (closed[closed.Count - 1].x == myself.x && closed[closed.Count - 1].y == myself.y)
                                break;

                        }
                    }

                    //is current closed list the shortest?
                    if (closed.Count > 0 && (shortClose.Count > closed.Count || shortClose.Count == 0))
                    {
                        shortClose = new List<Node>(closed);
                    }

                    //clean up before next iteration
                    open.Clear();
                    closed.Clear();
                }
            }
        }

        //find shortest path to nearest life pack
        public static void findClosestLifePack()
        {
            GameObject item, tempItem;
            int pos, x, y;
            int tempMotion, motion = -1;

            //clean history before start
            shortClose.Clear();

            for (y = 0; y < Arena.size; y++)
            {
                for (x = 0; x < Arena.size; x++)
                {
                    item = Arena.GetGameObject(x, y);

                    if (item is Life)
                    {
                        start = new Node();
                        start.f = 0;
                        start.g = 0;
                        start.h = 0;
                        start.x = x;
                        start.y = y;
                        start.motion = -1;
                        open.Add(start);

                        while (true)
                        {
                            //remove first element from open list and add it to close list
                            current = open[0];
                            closed.Add(current);
                            open.RemoveAt(0);

                            motion = current.motion;
                            tempMotion = -1;

                            for (int xT = current.x - 1; xT < current.x + 2; xT++)
                            {
                                if (xT < 0 || xT >= Arena.size) //out of bounds
                                    continue;

                                for (int yT = current.y - 1; yT < current.y + 2; yT++)
                                {
                                    //ignore current cell and diagonals
                                    if (!(xT == current.x ^ yT == current.y))
                                        continue;

                                    if (yT < 0 || yT >= Arena.size) //out of bounds
                                        continue;

                                    tempItem = Arena.GetGameObject(xT, yT);
                                    if (tempItem is StoneWall || tempItem is BrickWall || tempItem is Water ||
                                        (tempItem is Tank && ((Tank)tempItem).name != Tank.current_player_name))
                                        //obstacle or another tank! ignore
                                        continue;

                                    temp = new Node();
                                    temp.x = xT;
                                    temp.y = yT;
                                    temp.g = current.g + Math.Abs(xT - current.x) + Math.Abs(yT - current.y);

                                    //determine motion direction
                                    //add extra cost if direction must be changed
                                    if (xT > current.x)
                                    {
                                        if (motion != -1 && motion != RIGHT)
                                            temp.g++;
                                        tempMotion = RIGHT;
                                    }
                                    if (xT < current.x)
                                    {
                                        if (motion != -1 && motion != LEFT)
                                            temp.g++;
                                        tempMotion = LEFT;
                                    }
                                    if (yT > current.y)
                                    {
                                        if (motion != -1 && motion != DOWN)
                                            temp.g++;
                                        tempMotion = DOWN;
                                    }
                                    if (yT < current.y)
                                    {
                                        if (motion != -1 && motion != UP)
                                            temp.g++;
                                        tempMotion = UP;
                                    }

                                    temp.h = Math.Abs(xT - myself.x) + Math.Abs(yT - myself.y);
                                    temp.f = temp.g + temp.h;

                                    pos = open.IndexOf(temp);
                                    if (pos >= 0 && open[pos].g > temp.g)
                                    {
                                        open[pos].g = temp.g;
                                        open[pos].f = open[pos].g + open[pos].h;
                                    }
                                    else if (closed.IndexOf(temp) < 0)
                                    {
                                        temp.motion = tempMotion;
                                        open.Add(temp);
                                    }
                                }
                            }

                            //quit if nothing found
                            if (open.Count == 0)
                                break;

                            //sort open list
                            open.Sort(CompareNodes);

                            //exit condition
                            if (closed[closed.Count - 1].x == myself.x && closed[closed.Count - 1].y == myself.y)
                                break;

                        }
                    }

                    //is current closed list the shortest?
                    if (closed.Count > 0 && (shortClose.Count > closed.Count || shortClose.Count == 0))
                    {
                        shortClose = new List<Node>(closed);
                    }

                    //clean up before next iteration
                    open.Clear();
                    closed.Clear();
                }
            }
        }

        //comparator for non-increasing sort order
        private static int CompareNodes(Node n1, Node n2)
        {
            return n1.f - n2.f;
        }

        //generate move
        public static void move()
        {
            switch (shortClose[shortClose.Count - 1].motion)
            {
                case LEFT:
                    gameClient.SendToServer("RIGHT#");
                    break;
                case RIGHT:
                    gameClient.SendToServer("LEFT#");
                    break;
                case UP:
                    gameClient.SendToServer("DOWN#");
                    break;
                case DOWN:
                    gameClient.SendToServer("UP#");
                    break;
                //default:
                    //return false;
            }

            Thread.Sleep(500);
            //if we didn't hit the else, we have made a move
            //return true;
        }



        public static bool fire()
        {
            GameObject target;

            for (int i = myself.x + 1; i < Arena.size; i++)
            {
                target = Arena.GetGameObject(i, myself.y);
                if (target is Tank)
                {
                    //if already in that direction
                    if (myDirection == RIGHT)
                        gameClient.SendToServer("SHOOT#");
                    else
                        //turn to that direction
                        gameClient.SendToServer("RIGHT#");
                    return true;
                }
                else if (target is StoneWall)
                    return false;
            }

            for (int i = myself.y + 1; i < Arena.size; i++)
            {
                target = Arena.GetGameObject(myself.x, i);
                if (target is Tank)
                {
                    //if already in that direction
                    if (myDirection == DOWN)
                        gameClient.SendToServer("SHOOT#");
                    else
                        //turn to that direction
                        gameClient.SendToServer("DOWN#");
                    return true;
                }
                else if (target is StoneWall)
                    return false;
            }

            for (int i = myself.x - 1; i >= 0; i--)
            {
                target = Arena.GetGameObject(i, myself.y);
                if (target is Tank)
                {
                    //if already in that direction
                    if (myDirection == LEFT)
                        gameClient.SendToServer("SHOOT#");
                    else
                        //turn to that direction
                        gameClient.SendToServer("LEFT#");
                    return true;
                }
                else if (target is StoneWall)
                    return false;
            }

            for (int i = myself.y - 1; i >= 0; i++)
            {
                target = Arena.GetGameObject(myself.x, i);
                if (target is Tank)
                {
                    //if already in that direction
                    if (myDirection == UP)
                        gameClient.SendToServer("SHOOT#");
                    else
                        //turn to that direction
                        gameClient.SendToServer("UP#");
                    return true;
                }
                else if (target is StoneWall)
                    return false;
            }

            //if we reach here, no shooting could be done
            return false;
        }

        public static void sendServerMessage()
        {

        }
    }
}
