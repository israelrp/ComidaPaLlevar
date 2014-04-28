function MenuDetalle(){
    var ventanaMenu=Ti.UI.createWindow({
        width:'100%',
        height:'100%',
        backgroundColor:'white'
    });
    
    var btnCancel=Ti.UI.createButton({
        title:'Cancelar',
        bottom:50,
        left:50
    });
    ventanaMenu.add(btnCancel);
    
    
     var btnConfirmar=Ti.UI.createButton({
        title:'Confirmar',
        bottom:50,
        right:50
    });
    ventanaMenu.add(btnConfirmar);
    Titanium.Geolocation.accuracy = Titanium.Geolocation.ACCURACY_NEAREST_TEN_METERS;
    var lat;
    var long;
     
    //set the mapview with the current location
    var mapview = Map.createView({
        mapType: Map.STANDARD_TYPE,
        animate:true,
        region: {latitude:lat, longitude:long, latitudeDelta:0.005, longitudeDelta:0.005},
        regionFit:true,
        userLocation:false,
        visible: true,
        top: 170
    });
    
    ventanaMenu.add(mapview);
   
 
    Titanium.Geolocation.getCurrentPosition(function(e)
    {
        if (e.error)
        {
                currentLocation.text = 'error: ' + JSON.stringify(e.error);
    Ti.API.info("Code translation: "+translateErrorCode(e.code)); alert('error ' + JSON.stringify(e.error)); return; }
        var longitude = e.coords.longitude;
        var latitude = e.coords.latitude;
        var altitude = e.coords.altitude;
        var heading = e.coords.heading;
        var accuracy = e.coords.accuracy;
        var speed = e.coords.speed;
        var timestamp = e.coords.timestamp;
        var altitudeAccuracy = e.coords.altitudeAccuracy;
        //currentLocation.text = 'long:' + longitude + ' lat: ' + latitude;
        Titanium.API.info('geo - current location: ' + new Date(timestamp) + ' long ' + longitude + ' lat ' + latitude + ' accuracy ' + accuracy);
    
                // we use the above data the way we need it
    });
    Titanium.Geolocation.addEventListener('location',function(e)
    {
        if (e.error)
        {
                // manage the error
        return;
        }
    
        var longitude = e.coords.longitude;
        var latitude = e.coords.latitude;
        var altitude = e.coords.altitude;
        var heading = e.coords.heading;
        var accuracy = e.coords.accuracy;
        var speed = e.coords.speed;
        var timestamp = e.coords.timestamp;
        var altitudeAccuracy = e.coords.altitudeAccuracy;
        //currentLocation.text = 'long:' + longitude + ' lat: ' + latitude;
        Titanium.API.info('geo - current location: ' + new Date(timestamp) + ' long ' + longitude + ' lat ' + latitude + ' accuracy ' + accuracy);
        
               // again we use the gathered data
      });
    ventanaMenu.addEventListener('open',function(){
        //alert(JSON.stringify(detallesMenu));
        var imageMenu = Ti.UI.createImageView({
            image: detallesMenu.Imagen,
            top:5,
            width:150, height:150
        });
        ventanaMenu.add(imageMenu);
        var mapview = Map.createView({
        mapType: Map.STANDARD_TYPE,
        animate:true,
        regionFit:true,
        userLocation:true,
        region: {latitude: 37.78583526611328, longitude:-122.40641784667969, latitudeDelta:.01, longitudeDelta:.01},
        });
         
        ventanaMenu.add(mapview);
        //getLocation();
    });
    
    btnCancel.addEventListener('click',function(){
        winMenuDetalle.close();
    });
    //Titanium.Geolocation.addEventListener('location',getLocation);
    return ventanaMenu;
}
module.exports=MenuDetalle;