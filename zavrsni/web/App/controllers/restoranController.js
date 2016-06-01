web.controller('restoranController', ['$scope', 'authService', '$window', '$routeParams', 'jelaService', 'jela1Service', 'restoraniService', 'tipJelaService', 'odabranoJeloService', 'odabranoJelo1Service', function ($scope, authService, $window, $routeParams, jelaService, jela1Service, restoraniService, tipJelaService, odabranoJeloService, odabranoJelo1Service) {


    $scope.authentication = authService.authentication;
    $scope.ukupna_cijena = 0;
    $scope.ukupna_kolicina = 0;
    $scope.kosarica = [];
    $scope.kosarica_posalji = [];
    $scope.id = new Array();
    $scope.names = new Array();
    $scope.price = new Array();
    $scope.quantity = new Array();
    $scope.jela = null;
    $scope.tip = [];
    $scope.tipJela = [];
    $scope.id_restorana = null;
    $scope.id_restorana = jelaService.get();
    $scope.otvoren = null;
    $scope.restoran = null;
    $scope.klik = [];
    $scope.id_narudzbe = 0;
    $scope.id = 0;
    $scope.uklanjanje = 0;
    $scope.primljeno = 0;
    $scope.spremi = [];
    $scope.prikazi = 0;
   
    $scope.email = $scope.authentication.mail;

    restoraniService.getRestoraniByID($scope.id_restorana).then(function (result) {
        $scope.restoran = result.data;
        
    });

    jela1Service.getJelaByID($scope.id_restorana).then(function (result) {
        $scope.jela = result.data;
        for (i = 0; i < $scope.jela.length; i++) {
            tipJelaService.getTipJelaByID($scope.jela[i].tipJelaID).then(function (result) {
                $scope.tip[result.data[0].id] = result.data[0].naziv_tipa;
   
            });
        }
        
    });
  
    


    $scope.addItem = function (index, id, name, price, quantity) {
      
        if ($scope.authentication.ovlastID == 2) {
           
            $scope.klik[id] = 1;
            if ($scope.kosarica[id] == null) {
                $scope.price[id] = 0;
                $scope.quantity[id] = 0;
            }

            $scope.price[id] += price;
            $scope.quantity[id] += quantity;
          
            $scope.kosarica_posalji[index] = [id, $scope.quantity[id]];
            $scope.kosarica[id] = [name, $scope.price[id], $scope.quantity[id]];
            $scope.ukupna_cijena += price;
            $scope.ukupna_kolicina += quantity;
         
        }
        else {
            $scope.prikazi = 1;
        }
    }

    $scope.removeItem = function (index, id, name, price, quantity) {
        
        $scope.price[id] -= price;
        $scope.quantity[id] -= quantity;
        $scope.kosarica[id] = [name, $scope.price[id], $scope.quantity[id]];
        $scope.kosarica_posalji[index] = [id, $scope.quantity[id]];
        $scope.ukupna_cijena -= price ;
        $scope.ukupna_kolicina -= quantity;
        var zap = $scope.kosarica[id][2];
        if (zap == 0) {
            
            $scope.klik[id] = null;
            $scope.kosarica[id] = [null, null, null];
            
            
        }
        
        
    }

   

    $scope.potvrdi_narudzbu = function () {
        $scope.id_narudzbe += 1;
        $scope.uklanjanje = 1;
        time = getDateTime();
        vrijeme = time;
        var mail = $scope.email;
        time = time.split(":");
        moja_adresa = JSON.parse(localStorage.getItem("moja_adresa"));
        
        for (i = 0; i < $scope.kosarica_posalji.length ; i++) {
            if ($scope.kosarica_posalji[i] && $scope.kosarica_posalji[i][1] !=0) {
                $scope.spremi.push([time, $scope.kosarica_posalji[i][0], $scope.kosarica[$scope.kosarica_posalji[i][0]][0], $scope.kosarica[$scope.kosarica_posalji[i][0]][1], $scope.kosarica_posalji[i][1], $scope.id_restorana, moja_adresa[0], $scope.restoran[0].adresa, $scope.ukupna_cijena]);
                $scope.id += 1;
                
                odabranoJeloService.odaberiJelo($scope.id, $scope.kosarica_posalji[i], $scope.id_restorana, mail, moja_adresa, vrijeme, $scope.ukupna_cijena).then(function (result) {
                    $scope.primljeno = 1;

                });

            }
        }
        odabranoJelo1Service.set($scope.spremi);
        $scope.kosarica_posalji = [];
        //$scope.spremi = [];
    }


  
    $scope.reset = function () {
        $scope.ukupna_cijena = 0;
        $scope.ukupna_kolicina = 0;
        $scope.kosarica = [];
        $scope.kosarica_posalji = [];
        $scope.id = new Array();
        $scope.names = new Array();
        $scope.price = new Array();
        $scope.quantity = new Array();
        $scope.klik = [];
        $scope.uklanjanje = 0;
        $scope.primljeno = 0;
        $scope.prikazi = 0;
    }
    restoraniService.getRestoraniByID($scope.id_restorana).then(function (result) {
        $scope.restoran = result.data;
        var today = new Date().getHours();

        if (today >= $scope.restoran[0].vrijeme_otvaranja && today <= $scope.restoran[0].vrijeme_zatvaranja) {
            $scope.otvoren = 1;
        } else {
            $scope.otvoren = 0;
        }

    });

   
    function getDateTime() {

        var date = new Date();

        var hour = date.getHours();
        hour = (hour < 10 ? "0" : "") + hour;

        var min = date.getMinutes();
        min = (min < 10 ? "0" : "") + min;

        var sec = date.getSeconds();
        sec = (sec < 10 ? "0" : "") + sec;

        var year = date.getFullYear();

        var month = date.getMonth() + 1;
        month = (month < 10 ? "0" : "") + month;

        var day = date.getDate();
        day = (day < 10 ? "0" : "") + day;

        return year + ":" + month + ":" + day + ":" + hour + ":" + min + ":" + sec;

    }


}]);
