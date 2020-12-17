        $(document).ready(function () {
            function VAlidateName() {
                var name = $("#name").val();
                var nameRegex = /^[a-zA-Z]+$/;
                if (name.length == "") {
                    $("#spanValidate").html("Name should not be empty").css("display", "block");
                }
                else if (!nameRegex.test(name)) {
                    $("#spanValidate").html("Name should not contain number").css("display", "block");
                }
                else {
                    $("#spanValidate").html("").css("display", "inline-block");
                }
            }
            $("#name").blur(function () { VAlidateName(); });
            function ValidatePhoneNumer() {
                var phoneNumber = $("#phoneNumber").val();
                var phoneRegex = /^[6-9]{1}[0-9]{9}$/;
                if (phoneNumber.length == "") {
                    $("#spanValidatePhone").html("Phone number should not be empty").css("display", "block");
                }
                else if (!phoneRegex.test(phoneNumber)) {
                    $("#spanValidatePhone").html("Phone number should start from 6-9").css("display", "block");
                }
                else {
                    $("#spanValidatePhone").html("").css("display", "inline-block");
                }
            }
            $("#phoneNumber").blur(function () { ValidatePhoneNumer(); });
            function ValidateEmail() {
                var email = $("#email").val();
                //var emailRegex = /^[w-.+]+@[a-zA-Z0-9.-]+.[a-zA-z0-9]{2,4}$/;
                if (email.length == "") {
                    $("#spanValidateEmail").html("Email field should not be empty").css("display", "block");
                }
                //else if (!emailRegex.test(email)) {
                //    $("#spanValidateEmail").html("Email is invalid").css("display", "block");
                //}
                else {
                    $("#spanValidateEmail").html("").css("display", "inline-block");
                }
            }
            $("#email").blur(function () { ValidateEmail(); });
            function ValidateLoginUsername() {
                var email = $("#login_UserName").val();
                
                if (email.length == "") {
                    $("#spanValidateloginUserName").html("Email field is required").css("display", "block");
                }
                else {
                    $("#spanValidateloginUserName").html("").css("display", "inline-block");
                    
                }
            }
            $("#login_UserName").blur(function () { ValidateLoginUsername() });
            function ValidateLoginPassword() {
                var password = $("#login_Password").val();
                if (password.length == "") {
                    $("#spanValidateloginPassword").html("Password field is required").css("display", "block");
                }
                else {
                    $("#spanValidateloginPassword").html("").css("display", "inline-block");
                }
            }
            $("#login_Password").blur(function () { ValidateLoginPassword() });
        });