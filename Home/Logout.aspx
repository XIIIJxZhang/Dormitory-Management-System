<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="Dormitory_Management_System.Home.Logout" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Logout</title>
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

        .header-label2 {
            font-family: STXinwei;
            text-align: center;
            color: white;
            font-weight: bold;
            font-size: 30px;
            margin-top: -70px;
            margin-bottom: 40px;
            transition: transform 1.5s, opacity 1.5s;
        }

        .welcoming-label {
            font-family: STXinwei;
            text-align: center;
            color: greenyellow;
            font-weight: bold;
            font-size: 60px;
            position: absolute;
            margin-bottom: -1500px;
        }

        .footer-label {
            color: white;
            margin-top: 75px;
            margin-left: 35px;
            opacity: 0;
            transition: opacity 2s ease-in-out;
        }

        .button-container {
            margin-top: 150px;
            margin-left:5px;
            text-align: center;
            z-index: 1000;
            position: relative;
            opacity: 0;
            transform: translateY(20px);
            transition: opacity 1s ease-in-out, transform 1s ease-in-out;
        }

        .custom-button-container {
            display: inline-block;
            margin: 10px;
            position: relative;
            cursor: pointer;
        }

        .button-rectangle {
            width: 180px;
            height: 50px;
            background-color: teal;
            border-radius: 5px;
            transition: all 0.3s ease;
        }

        .button-text {
            position: absolute;
            left: 50%;
            top: 50%;
            transform: translate(-50%, -50%);
            color: white;
            font-size: 18px;
            font-weight: normal;
            cursor: pointer;
            user-select: none;
            transition: all 0.3s ease;
        }

        .custom-button-container:hover .button-rectangle {
            background-color: goldenrod;
            width: 200px;
            animation: buttonPulse 1s infinite;
        }

        @keyframes buttonPulse {
            0% {
                transform: scale(1);
                opacity: 1;
            }
            50% {
                transform: scale(1.05);
                opacity: 0.9;
            }
            100% {
                transform: scale(1);
                opacity: 1;
            }
        }

        .button-active .button-rectangle {
            animation: buttonFlash 0.5s infinite;
        }

        @keyframes buttonFlash {
            0% { background-color: teal; }
            50% { background-color: goldenrod; }
            100% { background-color: teal; }
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
</head>

<body>
    <form id="form1" runat="server">
        <div class="header-label2">
            E-Dormitory System<br />
        </div>

        <div class="welcoming-label">
            You have successfully logged out.<br />
        </div>

        <div class="button-container">
            <div class="custom-button-container" onclick="handleReLogin()">
                <div class="button-rectangle"></div>
                <asp:Label ID="lblReLogin" runat="server" Text="Re-Login" CssClass="button-text" />
            </div>
            <div class="custom-button-container" onclick="handleExit()">
                <div class="button-rectangle"></div>
                <asp:Label ID="lblExit" runat="server" Text="Exit" CssClass="button-text" />
            </div>
        </div>

        <div class="footer-label">
            Copyright © Designed by Gerrard, J X Zhang
        </div>
    </form>

    <script type="text/javascript">
        window.onload = function () {
            handleLoginSuccess();
        };

        function handleLoginSuccess() {
            const formContainer = document.querySelector('.form-container');
            const header2 = document.querySelector('.header-label2');
            const header3 = document.querySelector('.welcoming-label');
            const buttonContainer = document.querySelector('.button-container');
            const footer = document.querySelector('.footer-label');

            if (formContainer) {
                formContainer.style.transition = 'opacity 0.5s';
                formContainer.style.opacity = '0';
                formContainer.style.display = 'none';
            }

            if (header2) {
                header2.style.position = 'absolute';
                header2.style.top = '100px';
                header2.style.left = '50px';
            }

            if (header3) {
                header3.style.top = '-500px';
                header3.style.left = '250px';
            }

            const transitionStyle = 'transform 2s ease-in-out';
            if (header2) header2.style.transition = transitionStyle;
            if (header3) header3.style.transition = transitionStyle;

            if (header2) header2.style.transform = 'translateY(40px)';
            if (header3) header3.style.transform = 'translateY(700px)';

            // Add emerging effect for buttons
            setTimeout(() => {
                if (buttonContainer) {
                    buttonContainer.style.opacity = '1';
                    buttonContainer.style.transform = 'translateY(0)';
                }
            }, 1000);

            // Add emerging effect for footer
            setTimeout(() => {
                if (footer) {
                    footer.style.opacity = '1';
                }
            }, 1500);
        }

        function handleReLogin() {
            const button = event.currentTarget;
            button.classList.add('button-active');
            setTimeout(() => {
                window.location.href = '/Home/Login.aspx';
            }, 1500);
        }

        function handleExit() {
            const button = event.currentTarget;
            button.classList.add('button-active');
            setTimeout(() => {
                window.close();
                window.location.href = '/Home/Login.aspx';
            }, 500);
        }
    </script>
</body>
</html>