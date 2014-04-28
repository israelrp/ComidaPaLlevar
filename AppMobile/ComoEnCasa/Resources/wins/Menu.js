function Menu(){
    var VentanaMenuObjet=Ti.UI.createWindow({
        width:'100%',
        height:'100%',
        backgroundColor:'white'
    });
    
    
    var objMenu=[{
       Nombre:'Mole de panza',
       Descripcion:'Descripcion de la omida de panza' ,
       Imagen:'http://3.bp.blogspot.com/-qQN_C_IxjM0/TWR2tOc5ndI/AAAAAAAAAjg/GM8o7sfAyFM/s1600/panza+2.jpg'
    },
    {
       Nombre:'Albondigas',
       Descripcion:'Descripcion de las albondigas' ,
       Imagen:'http://www.philadelphia.com.mx/assets/uploads/Alb_ndigas-rellenas-en-caldillo-de-jitomate.jpg'
    },
    {
       Nombre:'Bistec',
       Descripcion:'Bisteces en salsa verde' ,
       Imagen:'http://4.bp.blogspot.com/-BxKWQi80YWk/USZtEsL3IdI/AAAAAAAAJJI/XP-AQ6wS9M0/s320/carnePuertoSalsaVerde.jpg'
    }
    ];
    
    VentanaMenuObjet.addEventListener('open',function(){
        var tableData = [];
        var urlMenus='http://cpln.azurewebsites.net/Api/ServiceMenu/RecuperarMenus';
        var clienteGetMenus=Ti.Network.createHTTPClient({
            onload:function(){
                var response=JSON.parse(this.responseText);
                Ti.API.info('respuesta: '+ response);
                for(var key in response){
                    var obj=response[key];
                    Ti.API.info('Nombre: '+ obj.Nombre);
                    
                    var row=Ti.UI.createTableViewRow({
                        className:'forumEvent', // used to improve table performance
                        selectedBackgroundColor:'white',
                        rowIndex:key, // custom property, useful for determining the row during events
                        height:110,
                        datos:obj
                    });
                    
                    var imageAvatar = Ti.UI.createImageView({
                        image: obj.Imagen,
                        left:10, top:5,
                        width:50, height:50
                    });
                    row.add(imageAvatar);
                    
                    var labelUserName = Ti.UI.createLabel({
                        color:'#576996',
                        font:{fontFamily:'Arial', fontSize:18, fontWeight:'bold'},
                        text:obj.Nombre,
                        left:70, top: 6,
                        width:200, height: 30
                    });
                    row.add(labelUserName);
                    
                    var labelDetails = Ti.UI.createLabel({
                        color:'#222',
                        font:{fontFamily:'Arial', fontSize:16, fontWeight:'normal'},
                        text:obj.Descripcion,
                        left:70, top:44,
                        width:360
                    });
                    row.add(labelDetails);
                    var labelPresio = Ti.UI.createLabel({
                        color:'red',
                        font:{fontFamily:'Arial', fontSize:16, fontWeight:'normal'},
                        text:'$ '+obj.Precio +'.00',
                        left:70, top:82,
                        width:360
                    });
                    row.add(labelPresio);
                    tableData.push(row);
                }
                //borra los hijos de esta ventana para quitar la tabla
                var tableView = Ti.UI.createTableView({
                  backgroundColor:'white',
                  data:tableData
                });
                
                VentanaMenuObjet.add(tableView);
                
                tableView.addEventListener('click',function(e){
                    var datos = e.rowData.datos;
                    //alert(JSON.stringify(datos));
                    detallesMenu=datos;
                    winMenuDetalle.open();
                });
            },
            onerror:function(){
                Ti.API.info('error');
            },
            timeout:50000
        });
        clienteGetMenus.open('Get',urlMenus);
        clienteGetMenus.send();
    });
    return VentanaMenuObjet;
}
module.exports=Menu;
