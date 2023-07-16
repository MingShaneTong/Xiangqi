# Xiangqi

The Xiangqi Game is an interactive online gaming application that brings the game of Xiangqi (also known as Chinese Chess) to your web browser. This project comprises a C# library for the Xiangqi game and web server and a web-based user interface, allowing players to play with opponents from around the world.

Xiangqi is a two-player board game that simulates a battle between two armies. Each player commands an army including the General, Advisors, Elephants, Horses, Chariots, Cannons, and Soldiers. The objective is to capture the opponent's General while protecting your own. 

![image](https://github.com/MingShaneTong/Xiangqi/assets/63452934/08db070f-e391-4fd1-a897-cc58a8aeb781)

## Features

- Online Multiplayer
- Responsive User Interface
- Move Highlighting
## Technologies Used

**C# Server:** The server-side of the application is built using C#, providing a robust and scalable infrastructure for handling game logic, managing player sessions, and facilitating real-time communication between players.

**Web-based User Interface:** The client-side of the application is implemented as a web-based user interface using HTML, CSS, and JavaScript. The UI leverages modern React.js to deliver a seamless and engaging gaming experience.

**Networking:** The application utilises SignalR, a library used to enable real-time communication between the server and client, ensuring smooth gameplay and real-time updates.

## Installation Guide

### Prerequisites
Before starting the installation process, ensure that you have the following prerequisites installed on your system:

- Docker - Make sure Docker is installed and running on your machine.
- Git - Install Git to clone the project repository (if applicable).

### Step 1: Clone the Repository
1. Open your terminal or command prompt.

2. Change to the directory where you want to clone the project.

3. Run the following command to clone the repository:

```
git clone https://github.com/your-username/your-repository.git
```

If you don't have Git installed, you can manually download the repository and extract it to your desired location.

### Step 2: Build the Docker Image
1. Navigate to the project's root directory in your terminal or command prompt.

2. Run the following command to build the Docker image:

```
docker build -t your-image-name .
```

### Step 3: Run the Docker Container
Once the Docker image is built, you can run a Docker container with the following command:

```
docker run -d -p 8080:80 your-image-name
```

This command runs the Docker container in detached mode (-d) and maps port 8080 of the host machine to port 80 of the container. Adjust the port mapping (-p) according to your requirements.

### Step 4: Access the Web Application
Open a web browser. Enter the following URL in the address bar:

```
http://localhost:8080
```

The web application should now be accessible through your browser. If everything was set up correctly, you should see the application's homepage.

Congratulations! You have successfully installed and deployed the C# web application using Docker containerization.
