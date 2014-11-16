function setMarkers(map) {

    var latitude = $("#latitude-textbox").val();
    var longitude = $("#longitude-textbox").val();

    var location = new google.maps.LatLng(longitude, latitude)

    var marker = new google.maps.Marker({
        position: location,
        map: map
    });

    return marker;
};