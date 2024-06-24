using System.Net.Sockets; // ���� ����� ���� ���ӽ����̽�
using System.Net; // IP �ּ� �� ��Ʈ��ũ ���� Ŭ����
using System.Text; // ���ڿ� ���ڵ� ���� Ŭ����
using ChatLib.Models; // ChatLib ���� ����ϱ� ���� ���ӽ����̽�

namespace ChatClient // ���ӽ����̽� ����
{
    public partial class Form1 : Form // Form Ŭ������ ��ӹ޴� Form1 Ŭ����
    {
        public Form1() // Form1 ������
        {
            InitializeComponent(); // �����̳ʿ��� ������ ������Ʈ�� �ʱ�ȭ�ϴ� �޼���
        }

        private TcpClient _client; // TCP Ŭ���̾�Ʈ ��ü

        // '����' ��ư Ŭ�� �� ȣ��Ǵ� �̺�Ʈ �ڵ鷯
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            _client = new TcpClient(); // TCP Ŭ���̾�Ʈ �ʱ�ȭ
            await _client.ConnectAsync(IPAddress.Parse("127.0.0.1"), 8880); // ������ �񵿱������� ����
            _ = HandleClient(_client); // Ŭ���̾�Ʈ ó�� �޼��� ȣ��
        }

        // �������� ����� ó���ϴ� �޼���
        private async Task HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream(); // ��Ʈ��ũ ��Ʈ�� ��ü
            byte[] buffer = new byte[1024]; // �����͸� �о�� ����
            int read; // ���� ����Ʈ ��

            // �����κ��� �����͸� ����ؼ� ���
            while ((read = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, read); // ����Ʈ �迭�� ���ڿ��� ��ȯ
                listBox1.Items.Add(message); // �޽����� ����Ʈ �ڽ��� �߰�

                // ���� �޽��� ���� ���̺� ������Ʈ
                lbCount.Text = listBox1.Items.Count.ToString();
            }
        }

        // '����' ��ư Ŭ�� �� ȣ��Ǵ� �̺�Ʈ �ڵ鷯
        private void btnSend_Click(object sender, EventArgs e)
        {
            NetworkStream stream = _client.GetStream(); // ��Ʈ��ũ ��Ʈ�� ��ü

            string text = textBox1.Text; // �ؽ�Ʈ �ڽ����� ���� �޽��� ��������
            ChatHub hub = new ChatHub // ChatHub ��ü ���� �� �ʱ�ȭ
            {
                UserId = 1,
                RoomId = 1,
                UserName = "human1",
                Message = text,
            };

            var messageBuffer = Encoding.UTF8.GetBytes(hub.ToJsonString()); // ChatHub ��ü�� JSON ���ڿ��� ��ȯ �� ����Ʈ �迭�� ���ڵ�

            var messageLengthBuffer = BitConverter.GetBytes(messageBuffer.Length); // �޽��� ���̸� ����Ʈ �迭�� ��ȯ

            stream.Write(messageLengthBuffer, 0, messageLengthBuffer.Length); // �޽��� ���� ����
            stream.Write(messageBuffer, 0, messageBuffer.Length); // ���� �޽��� ����
        }
    }
}
