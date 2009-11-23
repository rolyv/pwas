/*
CEN5011 Advanced Software Engineering
Term Project: Printshop workflow automation system
Author: Lenny Markus et all.
Date: Oct 4, 2009

XYZ.js:
Provides support for the neccesary DHTML functionality of the project
*/

/**
* login():
* Shows/Hides the login pop-up div, based on the bool setVisible
*/
function showLogin(setVisible)
{
 
 var display = setVisible?'visible':'hidden';
 document.getElementById('loginDiv').style.visibility = display;
 
}


/**
*doLogin():
*Sends login information to the system.
*/
function doLogin()
{
var usr = document.loginForm.user.value;
var pwd = document.loginForm.pwd.value;
var query = "user="+usr+"&pwd="+pwd+"&sid="+Math.random(); //Random nuber added to prevent stale/cached queries...
//alert('doing login : >'+query+'<');
var xmlhttp;
if (window.XMLHttpRequest)
  {
  // code for IE7+, Firefox, Chrome, Opera, Safari
  xmlhttp=new XMLHttpRequest();
  }
else if (window.ActiveXObject)
  {
  // code for IE6, IE5 //Sigh, Yes... might as well put it in.
  xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
  }
else
  {
  alert("Your browser does not support PWAS!");
  }
xmlhttp.onreadystatechange=function()
{
if(xmlhttp.readyState==4)
  {

  
  var response = xmlhttp.responseText;
  if (response == "ok")
    { 
	 window.location="/CEN/index.jsp"; //Reload login page.
	}
  else {document.getElementById("ERROR").innerHTML="Incorrect Username/Password";}
  }

}
xmlhttp.open('GET','/login/doLogin?'+query,true); //Call login server and wait for response
xmlhttp.send(null);
}
