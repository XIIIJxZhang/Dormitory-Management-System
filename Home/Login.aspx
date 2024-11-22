<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Dormitory_Management_System.Home.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link rel="stylesheet" href="../Assets/Lib/css/bootstrap.min.css"/>
    <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
            min-height: 100vh;
            background-image: url('../Assets/pic/login/LoginBackground.png');
            background-size: cover;
            background-position: center;
            background-attachment: fixed;
            margin: 0;
            overflow: hidden;
        }

        .container-fluid {
            position: relative;
            z-index: 1;
            margin: 0;
            padding: 0;
        }

        .form-container {
            padding: 15px;
            padding-top: 5px;
            border-radius: 15px;
            background: rgba(255, 255, 255, 0.15);
            border: 2px solid rgba(255, 255, 255, 0.4);
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.3);
        }

        .form-control {
            background-color: rgba(255, 255, 255, 0.8);
            border-radius: 5px;
        }

        .header-label1, .header-label2 {
            transition: transform 1.5s, opacity 1.5s;
        }

        .header-label1 {
            text-align: center;
            color: gold;
            font-weight: bold;
            font-size: 48px;
            margin-top: -20px;
            margin-bottom: 100px;
        }

        .header-label2 {
            font-family: STXinwei;
            text-align: center;
            color: white;
            font-weight: bold;
            font-size: 30px;
            margin-top: -70px;
            margin-bottom: 40px;
        }

        .welcoming-label {
            font-family: STXinwei;
            text-align: center;
            color: greenyellow;
            font-weight: bold;
            font-size: 70px;
            position: absolute;
            margin-bottom: -1500px;
            margin-left: 80px;
        }

        .footer-label {
            color: white;
            margin-top: 100px;
        }

        body::before {
            content: "";
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background: rgba(0, 0, 0, 0.2);
            z-index: 0;
        }
    </style>
    <script>
        function handleLoginSuccess() {
            // Slowly hide the login form (takes 0.5s)
            const formContainer = document.querySelector('.form-container');
            formContainer.style.transition = 'opacity 0.5s';
            formContainer.style.opacity = '0';  // Fade the form out to make it disappear slowly

            // Move headers to specific position (absolute positioning with slow movement)
            const header1 = document.querySelector('.header-label1');
            const header2 = document.querySelector('.header-label2');
            const header3 = document.querySelector('.welcoming-label');

            // Set timeout to ensure transitions are applied after form disappears
            setTimeout(() => {

                // Hide the form container completely after fading out
                formContainer.style.display = 'none';


                // Set absolute positioning for the labels (origin position on the page)
                header1.style.position = 'absolute';
                header1.style.top = '75px';   // Example: Set to 50px from the top of the page
                header1.style.left = '78px';  // Example: Set to 50px from the left of the page

                header2.style.position = 'absolute';
                header2.style.top = '100px';  // Example: Set to 100px from the top
                header2.style.left = '50px';  // Example: Set to 50px from the left

                header3.style.top = '800px';   // Example: Set to 50px from the top of the page
                header3.style.left = '225px';  // Example: Set to 50px from the left of the page

                // Apply transition for slow movement of the labels
                header1.style.transition = 'transform 2s ease-in-out';  // Slow movement of 2s
                header2.style.transition = 'transform 2s ease-in-out';  // Slow movement of 2s
                header3.style.transition = 'transform 2s ease-in-out';  // Slow movement of 2s

                // Move the headers down slowly with a negative translateY to move up
                header1.style.transform = 'translateY(100px)';
                header2.style.transform = 'translateY(40px)';
                header3.style.transform = 'translateY(-450px)';

                const footer = document.querySelector('.footer-label');
                footer.style.position = 'absolute';
                footer.style.transition = 'opacity 0.5s';  // Smooth fade out for the footer
                footer.style.opacity = '0';  // Fade out the footer

            }, 30);  // Set delay to 500ms to allow the form to fade out first

            // Show the "Welcome" button slowly (takes 0.5s)
        }
    </script>
</head>

<body>
    <!-- Header Label -->
    <div class="header-label1">
        The Chinese University of Hong Kong, Shenzhen<br />
    </div>

    <div class="header-label2">
        E - College System<br />
    </div>

    <div class="welcoming-label" onclick="rdtGo_Click()">
        Welcome! Redirecting......<br />
    </div>

    <!-- Login Setup -->
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4">
                <div class="form-container">
                    <form id="formLogin" runat="server">
                        <div class="mt-3">
                            <!-- ID Number -->
                            <img src="../Assets/pic/login/User.png" alt="User Icon" style="height: 40px; width: 40px; margin-right: -2px; margin-bottom: 15px"/>
                            <label for="idnumber" class="form-label" style="font-size: 25px; color:white">ID Number</label>
                            <input type="text" id="usrIDIn" placeholder="Your ID number" autocomplete="off" class="form-control" runat="server"/>
                        </div>
                        <div class="mt-3" style="margin-top:10px; margin-bottom:-25px">
                            <!-- Password -->
                            <img src="../Assets/pic/login/Password.png" alt="Pwd Icon" style="height: 35px; width: 35px; margin-left: 4px; margin-right: 3px; margin-bottom: 15px"/>
                            <label for="password" class="form-label" style="font-size: 25px; color:white">Password</label>
                            <input type="text" id="usrPwdIn" placeholder="Your password" autocomplete="off" class="form-control" runat="server"/>
                        </div>
                        <div class="mt-3 d-grid">
                            <div class="form-check mt-3" style="margin-top: 15px; color:white;">
                                <input type="checkbox" class="form-check-input" id="rememberMe" runat="server"/>
                                <label class="form-check-label" for="rememberMe">Keep me logged in</label>
                            </div>
                            </div>
                            <!-- Login and Reset Button -->
                            <div class="mt-3 d-flex justify-content-between" style="margin-top: 10px">
                                <asp:Label runat="server" ID="Errmsg" class="text-danger text-center"></asp:Label>
                                <asp:Button Text="Login" runat="server" class="btn btn-success btn-lg" style="width: 45%; margin-left:-30px; border-radius:0.25rem" ID="LoginBtn" OnClick="LoginBtn_Click"/>
                                <asp:Button Text="Reset" runat="server" class="btn btn-light btn-lg" style="width: 45%; border-radius:0.25rem" ID="ResetBtn"/>
                            </div>
                            
                    </form>
                </div>
            </div>
            <div class="col-md-4"></div>
        </div>
    </div>

    

    <div class="footer-label">
        Copyright © Designed by Gerrard, J X Zhang
    </div>
</body>
</html>
