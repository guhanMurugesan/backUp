var directionsService;
var map;
var mapAreaCollection = convertionToRouteModel(g_renderMapDetail);

$(document).ready(function () {
    google.maps.event.addDomListener(window, 'load', initialize);
});

function initialize() {
    directionsService = new google.maps.DirectionsService();
    //map created
    map = new google.maps.Map(document.getElementById('livemap'), {
        disableDefaultUI: false,
        zoom: 10,
        mapTypeId: google.maps.MapTypeId.TERRAIN
    });
    lookUpMapCollection(map, directionsService)
    google.maps.event.addListenerOnce(map, 'idle', AppDefaultZoom);
}

function lookUpMapCollection(map, directionsService) {
    mapAreaCollection.forEach(function (object, index) {
        object.directionDisplay.setMap(map);
        calculateAndDisplayRoute(map, directionsService, object.directionDisplay, object.origin, object.destination);
    });
}

function calculateAndDisplayRoute(map, directionsService, directionsDisplay, origin, destination) {
    directionsService.route({
        origin: origin,
        destination: destination,
        travelMode: google.maps.TravelMode.WALKING
    }, function (response, status) {
        if (status === google.maps.DirectionsStatus.OK) {
            directionsDisplay.setDirections(response);
        } else {
            window.alert('Directions request failed due to ' + status);
        }
    });
}
function AppDefaultZoom() {
    map.setZoom(17);
}
