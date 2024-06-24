using System.Net.Sockets; // ���� ����� ���� ���ӽ����̽�
using System.Net; // IP �ּ� �� ��Ʈ��ũ ���� Ŭ����
using System.Text; // ���ڿ� ���ڵ� ���� Ŭ����
using ChatLib.Models; // ChatLib ���� ����ϱ� ���� ���ӽ����̽�

namespace ChatServer // ���ӽ����̽� ����
{
    public partial class Form1 : Form // Form Ŭ������ ��ӹ޴� Form1 Ŭ����
    {
        public Form1() // Form1 ������
        {
            InitializeComponent(); // �����̳ʿ��� ������ ������Ʈ�� �ʱ�ȭ�ϴ� �޼���
        }

        private TcpListener _listener; // TCP ������ ��ü

        // '����' ��ư Ŭ�� �� ȣ��Ǵ� �̺�Ʈ �ڵ鷯
        private async void btnStart_Click(object sender, EventArgs e)
        {
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8880); // ���� ȣ��Ʈ�� 8880 ��Ʈ���� ������ �ʱ�ȭ
            _listener.Start(); // ������ ����

            // Ŭ���̾�Ʈ ������ ����ؼ� ���
            while (true)
            {
                TcpClient client = await _listener.AcceptTcpClientAsync(); // �񵿱������� Ŭ���̾�Ʈ ���� ���
                _ = HandleClient(client); // Ŭ���̾�Ʈ ó�� �޼��� ȣ��
            }
        }

        // Ŭ���̾�Ʈ ��û�� ó���ϴ� �޼���
        private async Task HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream(); // ��Ʈ��ũ ��Ʈ�� ��ü
            byte[] sizeBuffer = new byte[4]; // �޽��� ũ�⸦ ������ ����
            int read; // ���� ����Ʈ ��

            // Ŭ���̾�Ʈ���� ����� ����ؼ� ���
            while (true)
            {
                read = await stream.ReadAsync(sizeBuffer, 0, sizeBuffer.Length); // �޽��� ũ�� �б�
                if (read == 0) // ���� ����Ʈ�� 0�̸� ���� ����
                {
                    break;
                }

                int size = BitConverter.ToInt32(sizeBuffer, 0); // ����Ʈ �迭�� ������ ��ȯ�Ͽ� �޽��� ũ�� ���
                byte[] buffer = new byte[size]; // �޽����� ������ ����

                read = await stream.ReadAsync(buffer, 0, buffer.Length); // ���� �޽��� �б�
                if (read == 0) // ���� ����Ʈ�� 0�̸� ���� ����
                {
                    break;
                }

                string message = Encoding.UTF8.GetString(buffer, 0, read); // ����Ʈ �迭�� ���ڿ��� ��ȯ
                var hub = ChatHub.Parse(message)!; // JSON ���ڿ��� ChatHub ��ü�� �Ľ�

                // �޽����� ����Ʈ �ڽ��� �߰�
                listBox1.Items.Add($"UserId : {hub.UserId}, RoomId : {hub.RoomId}," + 
                    $" UserName : {hub.UserName}, Message : {hub.Message}");

                // Ŭ���̾�Ʈ���� ���� �޽��� ����
                var messageBuffer = Encoding.UTF8.GetBytes($"Server : {message}");
                stream.Write(messageBuffer, 0, messageBuffer.Length); // �޽��� ����

                // ���� �޽��� ���� ���̺� ������Ʈ
                lbCount.Text = listBox1.Items.Count.ToString();
            }
        }
    }
}
