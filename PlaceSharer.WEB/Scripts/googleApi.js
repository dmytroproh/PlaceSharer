var geocoder = new google.maps.Geocoder();
var markersArray = [];
var map;

function geocodePosition(pos) {
    geocoder.geocode({
        latLng: pos
    }, function (responses) {
        if (responses && responses.length > 0) {
            updateMarkerAddress(responses[0].formatted_address);
        } else {
            updateMarkerAddress('Cannot determine address at this location.');
        }
    });
}

function updateMarkerStatus(str) {
    document.getElementById('markerStatus').innerHTML = str;
}

function updateMarkerPosition(latLng) {
    document.getElementById('info').innerHTML = [
      latLng.lat(),
      latLng.lng()
    ].join(',      ');

    document.getElementById('GeoLat').value = latLng.lat();
    document.getElementById('GeoLong').value = latLng.lng();
}

function updateMarkerAddress(str) {
    //document.getElementById('address').innerHTML = str;
}

function initialize() {
    var latLng = new google.maps.LatLng(-34.397, 150.644);
    var map = new google.maps.Map(document.getElementById('mapCanvas'), {
        zoom: 1,
        center: latLng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });
    var marker = new google.maps.Marker({
        position: latLng,
        title: 'Point A',
        map: map,
        draggable: true
    });
           
   
    updateMarkerPosition(latLng);
    geocodePosition(latLng);

  
    google.maps.event.addListener(marker, 'dragstart', function () {
    });

    google.maps.event.addListener(marker, 'drag', function () {
        //updateMarkerStatus('Dragging...');
        updateMarkerPosition(marker.getPosition());
    });

    google.maps.event.addListener(marker, 'dragend', function () {
        //updateMarkerStatus('Drag ended');
        geocodePosition(marker.getPosition());
    });
    google.maps.event.addListener(map, "click", function (event) {
        placeMarker(event.latLng);
        updateMarkerPosition(event.latLng);
        marker.setPosition(event.latLng);
        geoLat = event.latLng.lat();
        geoLong = event.latLng.lng();
          
            });
}
function placeMarker(location) {
    
    deleteOverlays();

    var marker = new google.maps.Marker({
        position: location,
        map: map
    });

    markersArray.push(marker);

}

// Deletes all markers in the array by removing references to them
function deleteOverlays() {
    if (markersArray) {
        for (i in markersArray) {
            markersArray[i].setMap(null);
        }
        markersArray.length = 0;
    }
}

google.maps.event.addDomListener(window, 'load', initialize);