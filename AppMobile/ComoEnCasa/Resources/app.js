var VentanaMenu=require('wins/Menu');
var VentanaRegistro=require('wins/Registro');
var VentanaMenuDetalleObj=require('wins/DetalleMenu');
var Map = require('ti.map');
var detallesMenu=null;
var winPrincipal = Titanium.UI.createWindow({
  title:'My Window',
  backgroundColor:'#ffffff'
});
winPrincipal.open();  // open window

var lblUser=Ti.UI.createLabel({
    text:'Usuario:',
    top:100
});
winPrincipal.add(lblUser);

var txtUsuario=Ti.UI.createTextField({
    width:250,
    top:130,
    borderWidth:2
});
winPrincipal.add(txtUsuario);

var lblPassword=Ti.UI.createLabel({
    text:'Password:',
    top:160
});
winPrincipal.add(lblPassword);

var txtPassword=Ti.UI.createTextField({
    width:250,
    top:190,
    borderWidth:2,
    passwordMask:true
});
winPrincipal.add(txtPassword);

var btnLogin=Ti.UI.createButton({
    title:'Login',
    bottom:100,
    width:250,
    backgroundColor:'#58ACFA'
});

winPrincipal.add(btnLogin);

var btnNew=Ti.UI.createButton({
    title:'Register',
    bottom:50,
    width:250,
    backgroundColor:'#A9E2F3'
});

winPrincipal.add(btnNew);
var winMenu=new VentanaMenu();
var winRegistro=new VentanaRegistro();
var winMenuDetalle=new VentanaMenuDetalleObj();
btnLogin.addEventListener('click',function(){
    /*if(txtUsuario.value==''){
        alert('Falta usuario');
        return null;
    }
    if(txtPassword.value==''){
        alert('Falta password');
        return null;
    }
    var user=txtUsuario.value;
    var pwd=txtPassword.value;
    var url='http://cpln.azurewebsites.net/Api/ServiceUsuario/AutentiCar?email='+user+'&password='+pwd;
    Ti.API.info('Usuario: '+ user + '  Pwd: '+ pwd);
    var clientLogin=Ti.Network.createHTTPClient({
        onload:function(e){
            var response=JSON.parse(this.responseText);
            Ti.API.info('Respuesta: '+ response);
            winMenu.open();
        },
        onerror:function(e){
            Ti.API.info('Error');
        },
        timeout:50000
    });
     clientLogin.open('Get',url);
     clientLogin.send();*/
    winMenu.open();
});

btnNew.addEventListener('click',function(){
    winRegistro.open();
});
