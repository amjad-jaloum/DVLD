# DVLD - Driving & Vehicle License Department System

## Overview

**DVLD (Driving & Vehicle License Department)** is a desktop-based management system developed as an educational simulation of a real-world Driver and Vehicle Licensing Directorate.

This project is an educational version of Driver and Vehicle Licensing Directorate, a government body responsible for managing driver licenses, vehicle registrations, and related regulatory services.

The system automates and manages different licensing operations including issuing licenses, scheduling driving tests, renewing licenses, handling detained licenses, and managing users and applicants.

---

# Features

## Driver License Services

* Issue a new driving license for the first time
* Renew driving licenses
* Replace lost licenses
* Replace damaged licenses
* Release detained licenses
* Issue international driving licenses
* Retake failed driving tests

---

## Test Management

* Vision Test
* Written/Theory Test
* Practical Driving Test
* Schedule and manage test appointments
* Store test results and scores

---

## People Management

* Add new people
* Update person information
* Delete people
* Search by National Number
* Store personal photo and contact information

---

## User Management

* Create system users
* Manage permissions
* Freeze user accounts
* Edit and delete users

---

## License Management

* Manage local licenses
* Manage international licenses
* Detain and release licenses
* License history tracking

---

# Technologies Used

* **C#**
* **Windows Forms (WinForms)**
* **ADO.NET**
* **SQL Server**
* **3-Tier Architecture**
* **Object-Oriented Programming (OOP)**

---

# System Architecture

The project follows a **3-Tier Architecture**:

1. **Presentation Layer**

   * User Interface (Windows Forms)

2. **Business Logic Layer**

   * Handles validation and business rules

3. **Data Access Layer**

   * Database communication using ADO.NET

---

# Database Features

* Relational SQL Server Database
* Data Validation
* Relationships and Constraints
* Secure Authentication Handling

---

# Main Modules

| Module                  | Description                             |
| ----------------------- | --------------------------------------- |
| People Management       | Manage applicants and personal data     |
| Users Management        | Manage system users and permissions     |
| Applications Management | Handle license-related applications     |
| Tests Management        | Schedule and record tests               |
| License Services        | Renew, replace, and issue licenses      |
| Detained Licenses       | Manage detained and released licenses   |
| International Licenses  | Issue and manage international licenses |

---
# 🖼️ Application Screenshots
Below are the key interfaces of the application, showcasing the entire workflow from login to specialized license management.

### 🔐 Getting Started
<p align="center">
  <img src="Screenshots/screen%20(1).png" width="400" alt="Login Screen" />
  <img src="Screenshots/screen%20(2).png" width="400" alt="Main Menu Screen" />
</p>

### 📄 License Issuance Process
<p align="center">
  <img src="Screenshots/screen%20(3).png" width="260" alt="Adding Local License Screen" />
  <img src="Screenshots/screen%20(4).png" width="260" alt="Adding License Details" />
  <img src="Screenshots/screen%20(5).png" width="260" alt="Local License Management" />
</p>

### 👁️ Vision Testing & Appointments
<p align="center">
  <img src="Screenshots/screen%20(6).png" width="400" alt="Scheduling Vision Test" />
  <img src="Screenshots/screen%20(7).png" width="400" alt="Schedule Test Appointment" />
</p>

### 🚫 Detained Licenses
<p align="center">
  <img src="Screenshots/screen%20(8).png" width="400" alt="Releasing Detained License" />
  <img src="Screenshots/screen%20(9).png" width="400" alt="Detained Licenses Management" />
</p>

# Learning Outcomes

Through this project, the following concepts were practiced and implemented:

* Object-Oriented Programming (OOP)
* Layered Architecture
* Database Design
* SQL Server Integration
* Windows Forms Development
* Validation and Exception Handling
* Real-world Business Logic Implementation

---

# Future Improvements

* Convert the system into a Web Application
* Add QR Code verification
* Add Email/SMS notifications
* Add Reporting and Analytics
* Improve UI/UX design
* Add Multi-language support

---


## 🚀 Quick Start (Deployment Guide)

### Manual SQL Script Generation
1. Open **SQL Server Management Studio (SSMS)** and connect to your local server.
2. Open and execute the comprehensive script file found at: `/Database schema & data.sql` (Press `F5` to generate tables and insert data).
3. Launch the application executable.

# Author

**Amjad Jaloom**

---

# License

This project is created for educational purposes only.
