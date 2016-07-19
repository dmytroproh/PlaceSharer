
//$(document).ready(function () {
//    GetMap();
//});

//function GetMap() {
//    google.maps.visualRefresh = true;
//    var Moscow = new google.maps.LatLng(55.752622, 37.617567);

//    var mapOptions = {
//        zoom: 2,
//        center: Moscow,
//        mapTypeId: google.maps.MapTypeId.G_NORMAL_MAP
//    };


//    var map = new google.maps.Map(document.getElementById("canvas"), mapOptions);
//    var myLatlng = new google.maps.LatLng(55.752622, 37.617567);
//    var marker = new google.maps.Marker({
//        position: myLatlng,
//        map: map,
//    });

//    marker.setIcon('http://maps.google.com/mapfiles/ms/icons/red-dot.png')


//    $.getJSON('@Url.Action("GetData","Place")', function (data) {

//        $.each(data, function (i, item) {
//            var marker = new google.maps.Marker({
//                'position': new google.maps.LatLng(item.GeoLat, item.GeoLong),
//                'map': map,
//                'title': item.Name
//            });

//            marker.setIcon('http://maps.google.com/mapfiles/ms/icons/blue-dot.png')

//            google.maps.event.addListener(marker, 'click', function () {
//                infowindow.open(map, marker);
//            });
//        })
//    });
//}

$(document).ready(function () {
    GetMap();
});

function GetMap() {

    google.maps.visualRefresh = true;
    var Moscow = new google.maps.LatLng(55.752622, 37.617567);

    var mapOptions = {
        zoom: 2,
        center: Moscow,
        mapTypeId: google.maps.MapTypeId.G_NORMAL_MAP
    };


    var map = new google.maps.Map(document.getElementById("canvas"), mapOptions);


    var myLatlng = new google.maps.LatLng(55.752622, 37.617567);

    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title: 'Станции метро'
    });


    marker.setIcon('http://maps.google.com/mapfiles/ms/icons/red-dot.png')


    $.getJSON('@Url.Action("GetData","Place")', function (data) {

        $.each(data, function (i, item) {
            var marker = new google.maps.Marker({
                'position': new google.maps.LatLng(item.GeoLat, item.GeoLong),
                'map': map,
                'title': item.Name
            });


            marker.setIcon('http://maps.google.com/mapfiles/ms/icons/blue-dot.png')



            google.maps.event.addListener(marker, 'click', function () {
                infowindow.open(map, marker);
            });
        })
    });
}