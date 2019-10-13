console.log("xxxx");
const TOKEN = 'pk.eyJ1IjoiMzAyOTQ3MzE0IiwiYSI6ImNrMWxucXBmMzA1azYzc3F4dWRhNHhlenQifQ.tXx4h7GQJLOyIGUkGwc1Qw';
var locations = [];
$(".coordinates").each(function () {
    var longitude = $(".longitude", this).text().trim();
    var latitude = $(".latitude", this).text().trim();
    var address = $(".address", this).text().trim();
    // Create a point data structure to hold the values.
    var point = {
        "latitude": latitude,
        "longitude": longitude,
        "address": address
    };
    locations.push(point);
});

console.log("zzzzzz");
var data = [];
for (i = 0; i < locations.length; i++) {
    var feature = {
        "type": "Feature",
        "properties": {
            "address": locations[i].description,
            "icon": "circle-15"
        },
        "geometry": {
            "type": "Point",
            "coordinates": [locations[i].longitude, locations[i].latitude]
        }
    };
    data.push(feature)
}

mapboxgl.accessToken = TOKEN;
var map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/streets-v10',
    zoom: 11,
    center: [locations[0].longitude, locations[0].latitude]
});map.on('load', function () {
    
    map.addLayer({
        "id": "places",
        "type": "symbol",
        "source": {
            "type": "geojson",
            "data": {
                "type": "FeatureCollection",
                "features": data
            }
        },
        "layout": {
            "icon-image": "{icon}",
            "icon-allow-overlap": true
        }
    });    map.addControl(new MapboxGeocoder({        accessToken: mapboxgl.accessToken
    }));;    map.addControl(new mapboxgl.NavigationControl());    map.on('click', 'places', function (e) {
        var coordinates = e.features[0].geometry.coordinates.slice();
        var address = e.features[0].properties.address;        while (Math.abs(e.lngLat.lng - coordinates[0]) > 180) {
            coordinates[0] += e.lngLat.lng > coordinates[0] ? 360 : -360;
        }
        new mapboxgl.Popup()
            .setLngLat(coordinates)
            .setHTML(address)
            .addTo(map);
    });    map.on('mouseenter', 'places', function () {
        map.getCanvas().style.cursor = 'pointer';
    });    map.on('mouseleave', 'places', function () {
        map.getCanvas().style.cursor = '';
    });
});