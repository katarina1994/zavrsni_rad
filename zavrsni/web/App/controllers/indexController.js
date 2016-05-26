web.controller('indexController', ['$scope', '$window', 'restoraniService', 'userService', 'jela1Service', 'jelaService', '$route', function ($scope, $window, restoraniService, userService, jela1Service, jelaService, $route) {

    var res = new Array();
    $scope.restorani = null;
    $scope.aktivno = 0;
    var id = new Array();
    var popis_restorana = null;
    var moja_adresa = null;
    $scope.nadeniRestorani = [];
    var spremi = new Array();
    var my_latitude = null;
    var my_longitude = null;

    $scope.myInterval = 4000;
    $scope.slides = [

      {
          image: "/images/image1.jpg"
      },
      {
          image: "/images/image2.jpg"
      },
      {
          image: "/images/image3.jpg"
      },
      {
          image: "/images/image4.jpg"
      },
      {
          image: "/images/image5.jpg"
      },
      {
          image: "/images/image6.jpg"
      },
      {
          image: "/images/image7.jpg"
      },
      {
          image: "/images/image8.jpg"
      },
      {
          image: "/images/image9.jpg"
      },
      {
          image: "/images/image10.jpg"
      },
      {
          image: "/images/image11.jpg"
      },
      {
          image: "/images/image12.jpg"
      }
    ];

    $scope.getSecondIndex = function (index) {
        if (index - slides.length >= 0)
            return index - slides.length;
        else
            return index;
    }


    function getData() {
        restoraniService.getRestorani().then(function (result) {
            $scope.restorani = result.data;

        });
    }
    getData();


    $scope.contacts = [];
    $scope.address = '';
    var map;
    $scope.dodajAdresu = function () {

        $scope.contacts.push({ adresa: $scope.address });
        var geocoder = new google.maps.Geocoder();
        var address = $scope.address;

        geocoder.geocode({ 'address': address }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                my_latitude = results[0].geometry.location.lat();
                my_longitude = results[0].geometry.location.lng();



                angular.forEach($scope.restorani, function (value, key) {
                    angular.forEach(value.location, function (value, key) {
                        res.push(value.wellKnownText.split(" "));
                    });
                });

                for (i = 0; i < res.length ; i++) {

                    res[i][1] = parseFloat(res[i][1].match(/[+-]?((\.\d+)|(\d+(\.\d+)?)([eE][+-]?\d+)?)/g)) || [];
                    res[i][2] = parseFloat(res[i][2].match(/[+-]?((\.\d+)|(\d+(\.\d+)?)([eE][+-]?\d+)?)/g)) || [];
                }

                var destination = new Array();
                var origin = { lat: my_latitude, lng: my_longitude };
                for (i = 0; i < res.length ; i++) {
                    destination.push(new google.maps.LatLng(res[i][2], res[i][1]));
                }

                var service = new google.maps.DistanceMatrixService;
                service.getDistanceMatrix({
                    origins: [origin],
                    destinations: destination,
                    travelMode: google.maps.TravelMode.DRIVING,
                    unitSystem: google.maps.UnitSystem.METRIC,
                    avoidHighways: false,
                    avoidTolls: false
                }, function (response, status) {
                    if (status !== google.maps.DistanceMatrixStatus.OK) {
                        alert('Error was: ' + status);
                    } else {
                        var originList = response.originAddresses;
                        var destinationList = response.destinationAddresses;
                        $scope.address = originList[0];
                        localStorage["moja_adresa"] = JSON.stringify(originList);
                        $scope.dest_udalj = new Array;
                        var j = 0;
                        for (var i = 0; i < originList.length; i++) {
                            var results = response.rows[i].elements;

                            for (j = 0 ; j < results.length; j++) {
                                $scope.dest_udalj.push(parseFloat(results[j].distance.value / 1000));
                                if ((results[j].distance.value / 1000) < 1) {
                                    $scope.dest_udalj.push((parseFloat(results[j].distance.value / 1000)));
                                }
                            }

                            for (var k = 0; k < $scope.dest_udalj.length; k++) {

                                restoraniService.getRestoraniByID(k).then(function (result) {
                                    var rest = result.data;
                                    angular.forEach(rest, function (value, key) {
                                        if (value.radijusDostave >= $scope.dest_udalj[(value.id - 1)]) {
                                            $scope.nadeniRestorani.push(value);
                                            $scope.aktivno = 1;
                                        }

                                    });

                                    for (m = 0; m < $scope.nadeniRestorani.length; m++) {
                                        spremi[m] = $scope.nadeniRestorani[m].adresa;
                                    }
                                    localStorage["popis_restorana"] = JSON.stringify(spremi);

                                });

                            }

                        }
                    }
                });

            } else {
                alert("Molimo unesite adresu.")
            }

        });


        $scope.contacts = [];
        $scope.nadeniRestorani = [];
        res = [];
        spremi = [];


    }


    $scope.spremi_id = function (id) {
        //console.log(id);
        jelaService.set(id);
    }



    $scope.prikaziKartu = function () {
        popis_restorana = JSON.parse(localStorage.getItem("popis_restorana"));
        moja_adresa = JSON.parse(localStorage.getItem("moja_adresa"));

        map = new google.maps.Map(document.getElementById('map'), {
            center: { lat: my_latitude, lng: my_longitude },
            zoom: 12
        });
        var geocoder = new google.maps.Geocoder();
        var bounds = new google.maps.LatLngBounds;
        var markersArray = [];
        var destinationIcon = 'https://chart.googleapis.com/chart?' + 'chst=d_map_pin_letter&chld=D|FF0000|000000';
        var originIcon = 'https://chart.googleapis.com/chart?' + 'chst=d_map_pin_letter&chld=O|FFFF00|000000';
        var outputDiv = document.getElementById('output');
        outputDiv.innerHTML = '';
        deleteMarkers(markersArray);


        var showGeocodedAddressOnMap = function (asDestination) {
            var icon = asDestination ? destinationIcon : originIcon;
            return function (results, status) {

                if (status === google.maps.GeocoderStatus.OK) {
                    markersArray.push(new google.maps.Marker({
                        map: map,
                        position: results[0].geometry.location,
                        icon: icon
                    }));
                } else {
                    alert('Geocode was not successful due to: ' + status);
                }
            };
        };
        geocoder.geocode({ 'address': moja_adresa[0] },
           showGeocodedAddressOnMap(false));

        for (var j = 0; j < popis_restorana.length; j++) {
            geocoder.geocode({ 'address': popis_restorana[j] },
                showGeocodedAddressOnMap(true));
        }

        popis_restorana = null;
        moja_adresa = null;
    }

    function deleteMarkers(markersArray) {
        for (var i = 0; i < markersArray.length; i++) {
            markersArray[i].setMap(null);
        }
        markersArray = [];
    }


    moja_adresa = null;
    moja_adresa = JSON.parse(localStorage.getItem("moja_adresa"));
    userService.model.adresa = moja_adresa;
    if (userService.model.adresa[0] != null) {
        $scope.address = userService.model.adresa[0];
    }
    localStorage["popis_restorana"] = JSON.stringify([]);
    localStorage["moja_adresa"] = JSON.stringify([]);



    jela1Service.getJela().then(function (result) {
        $scope.jela = result.data;

    });



}]);
