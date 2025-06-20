# client.py
import socket

def run_client():
    # ��������� �������
    host = '127.0.0.1'
    port = 12345
    
    # ������� TCP/IP �����
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        # ������������ � �������
        s.connect((host, port))
        
        # ���������� ������
        message = "������, ������! ��� ������ �� Python."
        print(f"�������� �������: {message}")
        s.sendall(message.encode('utf-8'))
        
        # �������� ����� �� �������
        data = s.recv(1024)
        print(f"�������� �� �������: {data.decode('utf-8')}")

if __name__ == '__main__':
    run_client()