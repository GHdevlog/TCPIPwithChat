using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

// 공통 모듈을 통한 송수신
namespace ChatLib.Models
{
    public class ChatHub
    {
        public static ChatHub? Parse(string json) => JsonSerializer.Deserialize<ChatHub>(json);

        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int RoomId { get; set; }
        public string Message { get; set; } = string.Empty ;

        public string ToJsonString() => JsonSerializer.Serialize(this);

    }
}
