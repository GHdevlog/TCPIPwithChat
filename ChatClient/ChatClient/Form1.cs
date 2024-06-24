using System.Net.Sockets; // 소켓 통신을 위한 네임스페이스
using System.Net; // IP 주소 및 네트워크 관련 클래스
using System.Text; // 문자열 인코딩 관련 클래스
using ChatLib.Models; // ChatLib 모델을 사용하기 위한 네임스페이스

namespace ChatClient // 네임스페이스 선언
{
    public partial class Form1 : Form // Form 클래스를 상속받는 Form1 클래스
    {
        public Form1() // Form1 생성자
        {
            InitializeComponent(); // 디자이너에서 생성된 컴포넌트를 초기화하는 메서드
        }

        private TcpClient _client; // TCP 클라이언트 객체

        // '연결' 버튼 클릭 시 호출되는 이벤트 핸들러
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            _client = new TcpClient(); // TCP 클라이언트 초기화
            await _client.ConnectAsync(IPAddress.Parse("127.0.0.1"), 8880); // 서버에 비동기적으로 연결
            _ = HandleClient(_client); // 클라이언트 처리 메서드 호출
        }

        // 서버와의 통신을 처리하는 메서드
        private async Task HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream(); // 네트워크 스트림 객체
            byte[] buffer = new byte[1024]; // 데이터를 읽어올 버퍼
            int read; // 읽은 바이트 수

            // 서버로부터 데이터를 계속해서 대기
            while ((read = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, read); // 바이트 배열을 문자열로 변환
                listBox1.Items.Add(message); // 메시지를 리스트 박스에 추가

                // 현재 메시지 수를 레이블에 업데이트
                lbCount.Text = listBox1.Items.Count.ToString();
            }
        }

        // '전송' 버튼 클릭 시 호출되는 이벤트 핸들러
        private void btnSend_Click(object sender, EventArgs e)
        {
            NetworkStream stream = _client.GetStream(); // 네트워크 스트림 객체

            string text = textBox1.Text; // 텍스트 박스에서 보낼 메시지 가져오기
            ChatHub hub = new ChatHub // ChatHub 객체 생성 및 초기화
            {
                UserId = 1,
                RoomId = 1,
                UserName = "human1",
                Message = text,
            };

            var messageBuffer = Encoding.UTF8.GetBytes(hub.ToJsonString()); // ChatHub 객체를 JSON 문자열로 변환 후 바이트 배열로 인코딩

            var messageLengthBuffer = BitConverter.GetBytes(messageBuffer.Length); // 메시지 길이를 바이트 배열로 변환

            stream.Write(messageLengthBuffer, 0, messageLengthBuffer.Length); // 메시지 길이 전송
            stream.Write(messageBuffer, 0, messageBuffer.Length); // 실제 메시지 전송
        }
    }
}
