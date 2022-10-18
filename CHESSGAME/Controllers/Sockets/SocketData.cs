using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESSGAME.Controllers.Sockets
{
    [Serializable]
    public class SocketData
    {
        public int Command { get; set; }

        public Point Point { get; set; }
        public Point StartPoint { get; }
        public string Image { get; }
        public string Message { get; set; }

        public SocketData(int command, string message, Point point)
        {
            this.Command = command;
            this.Point = point;
            this.Message = message;
        }
        public SocketData(int command, string message, Point point, Point startPoint)
        {
            this.Command = command;
            this.Message = message;
            this.Point = point;
            StartPoint = startPoint;
        }
    }

    public enum SocketCommand
    {
        SEND_POINT,
        NOTIFY,
        NEW_GAME,
        UNDO,
        END_GAME,
        QUIT,
        SEND_PIECE
    }
}
