<?php

namespace Controllers;

use PDO;

class AdminController
{
    private $pdo;

    public function __construct(PDO $pdo)
    {
        $this->pdo = $pdo;
    }

    public function index()
    {
        // Извличане на данни за администратори
        $sql = "SELECT * FROM admins";
        $stmt = $this->pdo->query($sql);
        $admins = $stmt->fetchAll(PDO::FETCH_ASSOC);

        // Показване на изглед със списък на администратори
        return view('admin/index', ['admins' => $admins]);
    }

    public function create()
    {
        // Показване на изглед за създаване на нов администратор
        return view('admin/create');
    }

    public function store()
    {
        // Обработка на данни от формуляр за създаване
        $data = $_POST;

        // Валидиране на данни

        // Запис на данни в базата данни
        $sql = "INSERT INTO admins (username, email, password) VALUES (:username, :email, :password)";
        $stmt = $this->pdo->prepare($sql);
        $stmt->execute([
            ':username' => $data['username'],
            ':email' => $data['email'],
            ':password' => password_hash($data['password'], PASSWORD_DEFAULT),
        ]);

        // Пренасочване към списъка с администратори
        return redirect('/admin');
    }

    public function edit($id)
    {
        // Извличане на данни за администратор по ID
        $sql = "SELECT * FROM admins WHERE id = :id";
        $stmt = $this->pdo->prepare($sql);
        $stmt->execute([':id' => $id]);
        $admin = $stmt->fetch(PDO::FETCH_ASSOC);

        // Показване на изглед за редактиране на администратор
        return view('admin/edit', ['admin' => $admin]);
    }

    public function update($id)
    {
        // Обработка на данни от формуляр за редактиране
        $data = $_POST;

        // Валидиране на данни

        // Актуализиране на данни в базата данни
        $sql = "UPDATE admins SET username = :username, email = :email, password = :password WHERE id = :id";
        $stmt = $this->pdo->prepare($sql);
        $stmt->execute([
            ':username' => $data['username'],
            ':email' => $data['email'],
            ':password' => password_hash($data['password'], PASSWORD_DEFAULT),
            ':id' => $id,
        ]);

        // Пренасочване към списъка с администратори
        return redirect('/admin');
    }

    public function delete($id)
    {
        // Изтриване на администратор по ID
        $sql = "DELETE FROM admins WHERE id = :id";
        $stmt = $this->pdo->prepare($sql);
        $stmt->execute([':id' => $id]);

        // Пренасочване към списъка с администратори
        return redirect('/admin');
    }
}


