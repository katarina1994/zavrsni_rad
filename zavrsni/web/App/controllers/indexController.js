web.controller('indexController', ['$scope', '$window', 'restoraniService', 'jelaService', '$route', function ($scope, $window, restoraniService, jelaService, $route) {

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
          image: "http://www.yellowpages.rs/komitent_multimedia/3000/3069/slike/picerija_atos_-_pizza_trattoria.jpg"
      },
      {
          image: "http://www.piazzadeifiori.com/wp-content/uploads/2014/08/hrana_11.jpg"
      },
      {
          image: "http://4.bp.blogspot.com/-RaJcKEfxh5U/T3WgXtrCRyI/AAAAAAAAIqY/RonMqbisASs/s1600/metalac-kuvano+jelo_07.jpg" 
      },
      {
          image: "http://www.cef.hr/wp-content/uploads/2014/03/admin/jela-s-rostilja.jpg"
      },
      {
          image: "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcS_myGjbInhbDSwO46wMaOEN1CJ1eXS0yifOgrQzez5YqIKo0rSXQ"
      },
      {
          image: "http://kolaci.eu/wp-content/uploads/2011/11/kolac-s-nugatom-610x300.jpg"
      },
      {
          image: "http://tub.tubgit.com/reimg/resize-img.php?src=http://photos.up-wallpaper.com/images248/huv042xintk.jpg&h=450&w=728"
      },
      {
          image: "http://www.present.rs/sastav/kolaci/deesertni_kuvar017ss.jpg"
      },
      {
          image: "http://www.si-market.si/modules/store/uploads/strip_steak2.jpg"
      },
      {
          image: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR0l2wt9dOPpwAZzgxpH8-URquhYzMrTBgBI_QdjKwF8JSVam9CqA"
      },
      {
          image: "http://www.yellowpages.rs/komitent_multimedia/32300/32393/slike/restoran_saran_-_domaca_kuhinja.jpg"
      },
      {
          image: "http://glas-regije.com/wp-content/fotosiupload/2015/02/jela-od-ribe-post.jpg"
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

                                restoraniService.getRestoraniByDistance(k).then(function (result) {
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

}]);
