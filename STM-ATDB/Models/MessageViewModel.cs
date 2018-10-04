using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.MvcWeb.Models
{
    public class MessageViewModel
    {
        public MessageViewModel()
        {
            MessageType = ApplicationMessageType.Info;
        }

        public int IsError { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public IList<string> MessageList { get; set; } = new List<string>();
        public ApplicationMessageType MessageType { get; set; }

        public static MessageViewModel Success(string message)
        {
            return new MessageViewModel() { Title = "Success", MessageType = ApplicationMessageType.Success, Message = message, IsError = 0 };
        }

        public static MessageViewModel Success(string title, string message)
        {
            return new MessageViewModel() { Title = title, MessageType = ApplicationMessageType.Success, Message = message, IsError = 0 };
        }

        public static MessageViewModel Error(string message)
        {
            return new MessageViewModel() { Title = "Application Error", MessageType = ApplicationMessageType.Error, Message = message, IsError = 1 };
        }

        public static MessageViewModel Error(string title, string message)
        {
            return new MessageViewModel() { Title = title, MessageType = ApplicationMessageType.Error, Message = message, IsError = 1 };
        }

        public static MessageViewModel Info(string message)
        {
            return new MessageViewModel() { Title = "Information", MessageType = ApplicationMessageType.Info, Message = message , IsError = 0};
        }

        public static MessageViewModel Info(string title, string message)
        {
            return new MessageViewModel() { Title = title, MessageType = ApplicationMessageType.Info, Message = message, IsError = 0};
        }

        public static MessageViewModel Warning(string message)
        {
            return new MessageViewModel() { Title = "Warning", MessageType = ApplicationMessageType.Warning, Message = message, IsError = 0};
        }

        public static MessageViewModel Warning(string title, string message)
        {
            return new MessageViewModel() { Title = title, MessageType = ApplicationMessageType.Warning, Message = message, IsError = 0};
        }
    }

    public enum ApplicationMessageType
    {
        Info = 1,
        Warning = 2,
        Error = 4,
        Success = 8
    }
}
