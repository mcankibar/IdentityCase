# 📬 ASP.NET Core MVC Messaging App

This repository contains a **simple yet functional messaging web application** developed with **ASP.NET Core MVC**, **Entity Framework Core**, and **Bootstrap**. Users can **send**, **read**, **delete**, and **view details** of messages in a clean and user-friendly interface.

---

## 🖼️ Screenshots

### 📨 Inbox (Gelen Kutusu)
![Inbox Screenshot](emailcaseimages/scs2.png)

### 📧 Create New Message
![Create Message Screenshot](emailcaseimages/scs1.png)

### 🔍 Message Details
![Message Details Screenshot](emailcaseimages/scs5.png)

### ✅ SweetAlert - Success
![SweetAlert Success](emailcaseimages/scs4.png)

### ⚠️ SweetAlert - Warning
![SweetAlert Warning](emailcaseimages/scs3.png)

---

## 🚀 Features

- 📥 **Inbox & Sendbox** views for received and sent messages  
- ✉️ **New Message** creation with subject & content  
- 🗑️ **Delete messages** (soft delete logic with `isDeleted` flag)  
- 📄 **Message details** modal or view  
- 🧭 **Authorization** and session-based protection  
- 🚫 Prevents access to secured pages after logout  
- ⚠️ **SweetAlert** integration for user-friendly alerts  
- 🎨 **Responsive UI** with Bootstrap 5  
- 🗃️ Backend with **Entity Framework Core** and SQL Server  

---

## 🔐 Authentication & Authorization

- ✅ Login required to access Inbox, Sendbox, and message details  
- ❌ After logout, protected pages are no longer accessible  
- 🔒 `[Authorize]` attributes used to secure controllers and actions  
- 🔓 Login and Register pages are marked with `[AllowAnonymous]`

---

## 📦 Technologies Used

- ![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-%230074C8?style=for-the-badge)
- ![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-%234285F4?style=for-the-badge)
- ![Bootstrap](https://img.shields.io/badge/Bootstrap-%23563D7C?style=for-the-badge)
- ![SQL Server](https://img.shields.io/badge/SQL%20Server-%23CC2927?style=for-the-badge)
- ![SweetAlert2](https://img.shields.io/badge/SweetAlert2-%23FF5A5F?style=for-the-badge)

---



