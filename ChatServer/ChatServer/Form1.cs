using System.Net.Sockets; // 소켓 통신을 위한 네임스페이스
using System.Net; // IP 주소 및 네트워크 관련 클래스
using System.Text; // 문자열 인코딩 관련 클래스
using ChatLib.Models; // ChatLib 모델을 사용하기 위한 네임스페이스

namespace ChatServer // 네임스페이스 선언
{
    public partial class Form1 : Form // Form 클래스를 상속받는 Form1 클래스
    {
        public Form1() // Form1 생성자
        {
            InitializeComponent(); // 디자이너에서 생성된 컴포넌트를 초기화하는 메서드
        }

        private TcpListener _listener; // TCP 리스너 객체

        // '시작' 버튼 클릭 시 호출되는 이벤트 핸들러
        private async void btnStart_Click(object sender, EventArgs e)
        {
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8880); // 로컬 호스트의 8880 포트에서 리스너 초기화
            _listener.Start(); // 리스너 시작

            // 클라이언트 연결을 계속해서 대기
            while (true)
            {
                TcpClient client = await _listener.AcceptTcpClientAsync(); // 비동기적으로 클라이언트 연결 대기
                _ = HandleClient(client); // 클라이언트 처리 메서드 호출
            }
        }

        // 클라이언트 요청을 처리하는 메서드
        private async Task HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream(); // 네트워크 스트림 객체
            byte[] sizeBuffer = new byte[4]; // 메시지 크기를 저장할 버퍼
            int read; // 읽은 바이트 수

            // 클라이언트와의 통신을 계속해서 대기
            while (true)
            {
                read = await stream.ReadAsync(sizeBuffer, 0, sizeBuffer.Length); // 메시지 크기 읽기
                if (read == 0) // 읽은 바이트가 0이면 연결 종료
                {
                    break;
                }

                int size = BitConverter.ToInt32(sizeBuffer, 0); // 바이트 배열을 정수로 변환하여 메시지 크기 얻기
                byte[] buffer = new byte[size]; // 메시지를 저장할 버퍼

                read = await stream.ReadAsync(buffer, 0, buffer.Length); // 실제 메시지 읽기
                if (read == 0) // 읽은 바이트가 0이면 연결 종료
                {
                    break;
                }

                string message = Encoding.UTF8.GetString(buffer, 0, read); // 바이트 배열을 문자열로 변환
                var hub = ChatHub.Parse(message)!; // JSON 문자열을 ChatHub 객체로 파싱

                // 메시지를 리스트 박스에 추가
                listBox1.Items.Add($"UserId : {hub.UserId}, RoomId : {hub.RoomId}," + 
                    $" UserName : {hub.UserName}, Message : {hub.Message}");

                // 클라이언트에게 에코 메시지 전송
                var messageBuffer = Encoding.UTF8.GetBytes($"Server : {message}");
                stream.Write(messageBuffer, 0, messageBuffer.Length); // 메시지 전송

                // 현재 메시지 수를 레이블에 업데이트
                lbCount.Text = listBox1.Items.Count.ToString();
            }
        }
    }
}
