function Registro(){
    var registroWin=Ti.UI.createWindow({
        width:'100%',
        height:'100%',
        backgroundColor:'white'
    });
    
    var lblNombre=Ti.UI.createLabel({
        text:'Nombre:',
        top:100
    });
    registroWin.add(lblNombre);
    
    var txtNombre=Ti.UI.createTextField({
        width:250,
        top:130,
        borderWidth:2
    });
    registroWin.add(txtNombre);

    var lblEmail=Ti.UI.createLabel({
        text:'Email:',
        top:160
    });
    registroWin.add(lblEmail);
    
    var txtEmail=Ti.UI.createTextField({
        width:250,
        top:190,
        borderWidth:2
    });
    registroWin.add(txtEmail);
    
    var lblTelefono=Ti.UI.createLabel({
        text:'Telefono:',
        top:220
    });
    registroWin.add(lblTelefono);
    
    var txtTelefono=Ti.UI.createTextField({
        width:250,
        top:250,
        borderWidth:2
    });
    registroWin.add(txtTelefono);

    var lblPassword=Ti.UI.createLabel({
        text:'Password:',
        top:280
    });
    registroWin.add(lblPassword);
    
    var txtPassword=Ti.UI.createTextField({
        width:250,
        top:310,
        borderWidth:2
    });
    registroWin.add(txtPassword);
    
    var lblCPassword=Ti.UI.createLabel({
        text:'Confirmar Password:',
        top:340
    });
    registroWin.add(lblCPassword);
    
    var txtCPassword=Ti.UI.createTextField({
        width:250,
        top:370,
        borderWidth:2
    });
    registroWin.add(txtCPassword);
    
    
    var btnRegistro=Ti.UI.createButton({
        title:'Register',
        bottom:100,
        width:250,
        backgroundColor:'#58ACFA'
    });
    
    registroWin.add(btnRegistro);
    
    btnRegistro.addEventListener('click',function(){
        if(txtNombre.value==''||txtNombre.value==null){
            alert('Falta Nombre');
            return null;
        }
        if(txtEmail.value==''||txtEmail.value==null){
            alert('Falta Email');
            return null;
        }
        if(txtTelefono.value==''||txtTelefono.value==null){
            alert('Falta Telefono');
            return null;
        }
        if(txtPassword.value==''||txtPassword.value==null){
            alert('Falta Password');
            return null;
        }
        if(txtCPassword.value==''||txtCPassword.value==null){
            alert('Falta Confirmar password');
            return null;
        }
        if(txtPassword.value!=txtCPassword.value){
            alert('Las contraseñas no son iguales');
            return null;
        }
        
        var urlRegistro='http://cpln.azurewebsites.net/Api/ServiceUsuario/NuevoUsuario';
        var usuario={
            Nombre:txtNombre.value,
            Email:txtEmail.value,
            Telefono:txtTelefono.value,
            Password:txtPassword.value
        };
        var clienteRegistro=Ti.Network.createHTTPClient({
            onload:function(e){
                response=JSON.parse(this.responseText);
                Ti.API.info('Respuesta: + ' + response);
                alert('Operacion exitosa');
            },
            onerror:function(e){
                Ti.API.info('Error');
            },
            timeout:50000
        });
        clienteRegistro.open('Post',urlRegistro);
        clienteRegistro.send(usuario);
        registroWin.close();
    });
    
    return registroWin;
}
module.exports=Registro;
