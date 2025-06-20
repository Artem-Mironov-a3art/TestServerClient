# client.py
import socket

def run_client():
    # Настройки сервера
    host = '127.0.0.1'
    port = 12345
    
    # Создаем TCP/IP сокет
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        # Подключаемся к серверу
        s.connect((host, port))
        
        # Отправляем данные
        message = "Привет, сервер! Это клиент на Python."
        print(f"Отправка серверу: {message}")
        s.sendall(message.encode('utf-8'))
        
        # Получаем ответ от сервера
        data = s.recv(1024)
        print(f"Получено от сервера: {data.decode('utf-8')}")

if __name__ == '__main__':
    run_client()