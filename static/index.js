$(".option").click(function(){
    $(".option").removeClass("active");
    $(this).addClass("active");
    
 });
 


 $(function() {
    window.addEventListener('message', function(event) { 
        var item = event.data;
        if (item.showAuth == true) {
            document.getElementsByClassName("main")[0].style.display = "block";

            if (item.error != "NOE")
            {
                document.getElementById("error_message").innerHTML = item.error
                document.getElementById("error_message").style.display = "block"  
            }
        } 
        else 
        {
            document.getElementsByClassName("main")[0].style.display = "none";
        }


    });


    $("#submit_login").click(function() {
        var user = $("#logname").val();
        var pass = $("#logpass").val();

        fetch(`https://auth-interface/login_nui`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
                username: user,
                password: pass
            })
        }).then(resp => resp.json()).then(
            resp => document.getElementById("error_message").innerHTML = resp["error"]
            ).then(
                resp => document.getElementById("error_message").style.display = "block"   
            );

    });


 });